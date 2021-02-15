using System.ComponentModel.DataAnnotations.Schema;

namespace NetworkModelCode.Core.Domain.Entities
{
    public class TechnologicalCondition : BaseEntity
    {
        public string Title { get; set; }

        public int CodeI { get; set; }
       
        public int CodeJ { get; set; }

        public double TimeMin { get; set; }

        public double TimeMax { get; set; }

        public int Time { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public override bool Equals(object obj)
        {
            var itemDataSource = obj as TechnologicalCondition;

            if (itemDataSource == null)
                return false;

            return
                (this.CodeI == itemDataSource.CodeI) && (this.CodeJ == itemDataSource.CodeJ)
                && (this.TimeMin == TimeMin) && (this.TimeMax == TimeMax)
                ? true : false;
        }

        public override int GetHashCode()
        {
            return Id * 2;
        }
    }

    public static class WorkDataSourceExtension
    {
        public static string ToStringCustom(this TechnologicalCondition itemDataSource)
        {
            return $"{itemDataSource.Title} {itemDataSource.CodeI} {itemDataSource.CodeJ} " +
                $"{itemDataSource.Time}";
        }
    }
}
