using AsmResolver;
using AsmResolver.DotNet;
using ProwlynxNET.Core.Models.Services;
using ProwlynxNET.Core.Services.Argument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Services.Marker
{
    /// <summary>
    ///     Processes attributes in an <see cref="ObfuscationTask" /> module.
    ///     Adds them to the <see cref="MarkerService" />.
    /// </summary>
    public class AttributeReader
    {
        #region Fields

        private readonly Regex _argRegex =
            new Regex(@"([A-Za-z0-9]+)(\(([\w\s""',-=\-:!@#$%^&*+]+)\)|)", RegexOptions.Compiled);

        private readonly string? _attrType = typeof(ObfuscationAttribute).Name;
        private IAttributeArgumentService<ArgumentInfo>? _arg;
        private IMarkerService? _marker;
        private ObfuscationTask? _task;

        #endregion

        #region Public Methods

        /// <summary>
        ///     Read and add to the marker the obfuscation information stored in attributes.
        /// </summary>
        /// <param name="task">The obfuscation task.</param>
        public void Read(ObfuscationTask task)
        {
            _task = task;
            _arg = _task.AttributeArgumentService;
            _marker = _task.Marker;

            foreach (var td in _task.Module!.GetAllTypes())
            {
                if (td.CustomAttributes.Count > 0) Read(td, td.CustomAttributes);
                foreach (var md in td.Methods)
                    if (md.CustomAttributes.Count > 0)
                        Read(md, md.CustomAttributes);
                foreach (var pd in td.Properties)
                    if (pd.CustomAttributes.Count > 0)
                        Read(pd, pd.CustomAttributes);
                foreach (var ed in td.Events)
                    if (ed.CustomAttributes.Count > 0)
                        Read(ed, ed.CustomAttributes);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Read the custom attributes and add them to the marker service.
        /// </summary>
        /// <param name="def">The definition to associate with the <see cref="ObfuscationInfo" /></param>
        /// <param name="attrs">The collection of custom attributes from the definition</param>
        private void Read(IMemberDefinition def, IList<CustomAttribute> attrs)
        {
            foreach (var ca in new List<CustomAttribute>(attrs))
            {
                if (ca.Constructor?.DeclaringType?.Name != _attrType) continue;
                
                (List<ObfuscationInfo> obfInfo, List<ArgumentInfo> argInfo) = GetInfos(def, ca);

                foreach (var info in obfInfo) _marker!.AddMark(info);
                foreach (var info in argInfo) _arg!.Add(info);
            }
        }

        // TODO: Update.
        /// <summary>
        ///     Get the list of <see cref="ObfuscationInfo" /> and <see cref="ArgumentInfo" /> for the custom attribute.
        ///     A single attribute can have multiple protection names stored in the Feature argument.
        ///     Format for a feature is: ExampleProtection(a = b, c = d, "d"="e, test", e = f) or ExampleProtection
        /// </summary>
        /// <param name="def">The definition to associate with the created <see cref="ObfuscationInfo" /></param>
        /// <param name="ca">The custom attribute.</param>
        /// <returns>List of obfuscation information for the custom attribute.</returns>
        private (List<ObfuscationInfo>, List<ArgumentInfo>) GetInfos(IMemberDefinition def, CustomAttribute ca)
        {
            List<ObfuscationInfo> infos = new List<ObfuscationInfo>();
            List<ArgumentInfo> args = new List<ArgumentInfo>();

            List<string> protectionNames = new List<string>();
            MatchCollection? argMatches = null;

            var exclude = false;
            var applyToMembers = false;
            var stripAfterObfuscation = true;
            if (ca.Signature == null)
            {
                return (infos, args);
            }
            foreach (var arg in ca.Signature!.NamedArguments)
            {
                object? argValue = arg.Argument.Element;
                if (argValue == null) continue;

                switch (arg.MemberName)
                {
                    case "Feature":
                        argMatches = _argRegex.Matches(((Utf8String)argValue).Value);
                        break;
                    case "Exclude":
                        exclude = (bool)argValue;
                        break;
                    case "ApplyToMembers":
                        applyToMembers = (bool)argValue;
                        break;
                    case "StripAfterObfuscation":
                        stripAfterObfuscation = (bool)argValue;
                        break;
                }
            }
            if (argMatches != null)
                foreach (Match m in argMatches)
                {
                    var argInfo = new ArgumentInfo(m.Groups[3].Value)
                    {
                        ApplyToMembers = applyToMembers,
                        Def = def,
                        Name = m.Groups[1].Value,
                        Exclude = exclude
                    };
                    args.Add(argInfo);

                    // Add it as a protection name for later on...
                    protectionNames.Add(m.Groups[1].Value);
                }

            foreach (string name in protectionNames)
                infos.Add(new ObfuscationInfo
                {
                    ApplyToMembers = applyToMembers,
                    Exclude = exclude,
                    Name = name,
                    Def = def
                });

            if (stripAfterObfuscation)
                ((dynamic)def).CustomAttributes.Remove(ca);

            return (infos, args);
        }

        #endregion
    }
}
