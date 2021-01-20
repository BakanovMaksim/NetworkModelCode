using System;

namespace NetworkModelCode.Core.Domain.Entities
{
    public class WorkDataSource : BaseEntity
    {
        public Guid WorkManagerId { get; set; }

        public int CodeI { get; set; }
        
        public int CodeJ { get; set; }

        public int Time { get; set; }
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
