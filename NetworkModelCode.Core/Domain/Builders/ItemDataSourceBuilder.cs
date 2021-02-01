using NetworkModelCode.Core.Domain.Entities;

namespace NetworkModelCode.Core.Domain.Builders
{
    public sealed class ItemDataSourceBuilder
    {
        private ItemDataSource ItemDataSource { get; }

        public ItemDataSourceBuilder()
        {
            ItemDataSource = new();
        }

        public ItemDataSourceBuilder SetTitle(string title)
        {
            ItemDataSource.Title = title;
            return this;
        }

        public ItemDataSourceBuilder SetCode(int i, int j)
        {
            ItemDataSource.CodeI = i;
            ItemDataSource.CodeJ = j;
            return this;
        }

        public ItemDataSourceBuilder SetTime(int time)
        {
            ItemDataSource.Time = time;
            return this;
        }

        public ItemDataSource Build()
        {
            return ItemDataSource;
        }
    }
}
