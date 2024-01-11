using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProwlynxNET.Core.Models;

namespace ProwlynxNET.Core.Protections
{
    /// <summary>
    ///     Base of all protections.
    /// </summary>
    public abstract class ProtectionBase : IProtection
    {
        #region Public Properties

        /// <inheritdoc />
        public abstract string ProtectionName { get; set; }

        /// <summary>
        ///     Whether the protection or stage has stages.
        /// </summary>
        public bool HasStages => Stages.Count > 0;

        /// <inheritdoc />
        public List<IProtectionStage> Stages
        {
            get
            {
                if (_orderedStages) return _stages;

                // Order the stages by stage priority, then protection priority.
                _stages = _stages.OrderBy(s => s.StagePriority)
                                 .ThenBy(s => s.ProtectionPriority)
                                 .ToList();
                _orderedStages = !_orderedStages;

                return _stages;
            }
            set => _stages = value;
        }

        /// <inheritdoc />
        public abstract int ProtectionPriority { get; set; }

        #endregion

        #region Fields

        private bool _orderedStages;
        private List<IProtectionStage> _stages = new List<IProtectionStage>();

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public List<T> GetStages<T>() where T : IProtectionStage
        {
            return Stages.Where(stage => stage is T).Cast<T>().ToList();
        }

        /// <inheritdoc />
        public T? GetStage<T>() where T : IProtectionStage
        {
            return (T?)Stages.FirstOrDefault(stage => stage is T);
        }

        #endregion
    }
}
