using System;

namespace NetworkModelCode.Core.Domain.Entities
{
    public class WorkDataSource : BaseEntity
    {
        public Guid WorkManagerId { get; set; }

        public int CodeI { get; set; }
       
        public int CodeJ { get; set; }

        public int Time { get; set; }

        public override bool Equals(object obj)
        {
            var workDataSource = obj as WorkDataSource;

            if (workDataSource == null)
                return false;

            return
                (this.CodeI == workDataSource.CodeI) && (this.CodeJ == workDataSource.CodeJ) && (this.Time == workDataSource.Time)
                ? true : false;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }

    public static class WorkDataSourceExtension
    {
        public static string ToStringCustom(this WorkDataSource workDataSource)
        {
            return $"{workDataSource.CodeI}-{workDataSource.CodeJ} " +
                $"{workDataSource.Time}";
        }
    }
}
