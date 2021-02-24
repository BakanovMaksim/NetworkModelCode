using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

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

        public double ResourceCapacity { get; set; }

        public double ResourceConsumptionMin { get; set; }

        public double ResourceConsumptionMax { get; set; }

        public double ResourceConsumption { get; set; }

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

    public static class TechnologicalConditionExtension
    {
        public static string ToStringCustom(this TechnologicalCondition technologicalCondition)
        {
            return $"{technologicalCondition.Title} {technologicalCondition.CodeI} {technologicalCondition.CodeJ} " +
                $"{technologicalCondition.Time}";
        }
    }
}
