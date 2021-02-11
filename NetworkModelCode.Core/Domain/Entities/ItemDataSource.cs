using System.ComponentModel.DataAnnotations.Schema;

namespace NetworkModelCode.Core.Domain.Entities
{
    public class ItemDataSource : BaseEntity
    {
        public string Title { get; set; }

        public int CodeI { get; set; }
       
        public int CodeJ { get; set; }

        public int Time { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public override bool Equals(object obj)
        {
            var itemDataSource = obj as ItemDataSource;

            if (itemDataSource == null)
                return false;

            return
                (this.CodeI == itemDataSource.CodeI) && (this.CodeJ == itemDataSource.CodeJ) && (this.Time == itemDataSource.Time)
                ? true : false;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }

    public static class WorkDataSourceExtension
    {
        public static string ToStringCustom(this ItemDataSource itemDataSource)
        {
            return $"{itemDataSource.Title} {itemDataSource.CodeI} {itemDataSource.CodeJ} " +
                $"{itemDataSource.Time}";
        }
    }
}
