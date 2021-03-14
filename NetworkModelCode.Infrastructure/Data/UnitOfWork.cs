using NetworkModelCode.Infrastructure.Data.Repositories;

namespace NetworkModelCode.Infrastructure.Data
{
    public class UnitOfWork 
    {
        private NetworkModelContext Context { get; }

        private ProjectRepository projectRepository;
        private TechnologicalConditionRepository technologicalConditionRepository;
        private TimeCharacteristicsRepository timeCharacteristicRepository;

        public ProjectRepository Projects
        {
            get
            {
                if (projectRepository == null)
                    projectRepository = new ProjectRepository(Context);
                return projectRepository;
            }
        }

        public TechnologicalConditionRepository TechnologicalConditions
        {
            get
            {
                if (technologicalConditionRepository == null)
                    technologicalConditionRepository = new TechnologicalConditionRepository(Context);
                return technologicalConditionRepository;
            }
        }

        public TimeCharacteristicsRepository TimeCharacteristics
        {
            get
            {
                if (timeCharacteristicRepository == null)
                    timeCharacteristicRepository = new TimeCharacteristicsRepository(Context);
                return timeCharacteristicRepository;
            }
        }

        public UnitOfWork(NetworkModelContext context)
        {
            Context = context;
        }
    }
}
