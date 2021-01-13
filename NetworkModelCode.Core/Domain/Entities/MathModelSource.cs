﻿using System.Collections.Generic;

namespace NetworkModelCode.Core.Domain.Entities
{
    /// <summary>
    /// Исходные параметры.
    /// </summary>
    public class MathModelSource : BaseEntity
    {
        public int NumberWorkCount { get; set; }

        /// <summary>
        /// Код работы.
        /// </summary>
        public IReadOnlyList<WorkCode> WorkCodes { get; set; }

        /// <summary>
        /// Длительность выполнения i-ой работы (t).
        /// </summary>
        public IReadOnlyList<int> ExecutionTimes { get; set; }
    }

    public class WorkCode
    {
        public int I { get; }

        public int J { get; }

        public WorkCode(int i,int j)
        {
            I = i;
            J = j;
        }

        public static bool operator ==(WorkCode workCodeLeft, WorkCode workCodeRight)
        {
            if ((workCodeLeft == null) || (workCodeRight == null))
                return false;

            return workCodeLeft.Equals(workCodeRight);
        }

        public static bool operator !=(WorkCode workCodeLeft, WorkCode workCodeRight)
        {
            if ((workCodeLeft == null) || (workCodeRight == null))
                return false;

            return !workCodeLeft.Equals(workCodeRight);
        }

        public override bool Equals(object obj)
        {
            var workCode = obj as WorkCode;

            if (workCode == null)
                return false;

            return (this.I == workCode.I) && (this.J == workCode.J) ? true : false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
