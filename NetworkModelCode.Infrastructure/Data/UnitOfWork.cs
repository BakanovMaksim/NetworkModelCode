using NetworkModelCode.Infrastructure.Data.Repositories;

namespace NetworkModelCode.Infrastructure.Data
{
    public class UnitOfWork 
    {
        private NetworkModelContext Context { get; }

        private ProjectRepository projectRepository;
        private ItemDataSourceRepository itemDataSourceRepository;
        private ItemTimeCharacteristicRepository itemTimeCharacteristicRepository;

        public ProjectRepository Projects
        {
            get
            {
                if (projectRepository == null)
                    projectRepository = new ProjectRepository(Context);
                return projectRepository;
            }
        }

        public ItemDataSourceRepository ItemsDataSource
        {
            get
            {
                if (itemDataSourceRepository == null)
                    itemDataSourceRepository = new ItemDataSourceRepository(Context);
                return itemDataSourceRepository;
            }
        }

        public ItemTimeCharacteristicRepository ItemsTimeCharacteristic
        {
            get
            {
                if (itemTimeCharacteristicRepository == null)
                    itemTimeCharacteristicRepository = new ItemTimeCharacteristicRepository(Context);
                return itemTimeCharacteristicRepository;
            }
        }

        public UnitOfWork(NetworkModelContext context)
        {
            Context = context;
        }
    }
}
