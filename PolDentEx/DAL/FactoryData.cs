using PolDentEx.RepositoryFacade;

namespace PolDentEx.DAL
{
    public class FactoryData
    {
        private DataSourceEnum _source;

        public FactoryData(DataSourceEnum source)
        {
            _source = source;
        }

        public AppointmentFacade GetAppointmentFacade()
        {
            IAppointmentRepository repository;

            if(_source == DataSourceEnum.Database)
                repository = new AppointmentRepository();
            else
                repository = new AppointmentApiRepository();

            return new AppointmentFacade(repository);
        }

        public DoctorFacade GetDoctorFacade()
        {
            IDoctorRepository repository;

            if(_source == DataSourceEnum.Database)
                repository = new DoctorRepository();
            else
                repository = new DoctorApiRepository();

            return new DoctorFacade(repository);
        }

        public PatientFacade GetPatientFacade()
        {
            IPatientRepository repository;
            IPatientCardRepository cardRepository;
            IPatientDetailsRepository detailsRepository;
            IToothRepository toothRepository;

            if (_source == DataSourceEnum.Database)
            {
                repository = new PatientRepository();
                cardRepository = new PatientCardRepository();
                detailsRepository = new PatientDetailsRepository();
                toothRepository = new ToothRepository();
            }
            else
            {
                repository = new PatientApiRepository();
                cardRepository = new PatientCardApiRepository();
                detailsRepository = new PatientDetailsApiRepository();
                toothRepository = new ToothApiRepository();
            }

            return new PatientFacade(repository, cardRepository, detailsRepository, toothRepository);
        }

        public ToothFacade GeToothFacade()
        {
            IToothRepository repository;

            if (_source == DataSourceEnum.Database)
                repository = new ToothRepository();
            else
                repository = new ToothApiRepository();

            return new ToothFacade(repository);
        }

        public TreatmentFacade GeTreatmentFacade()
        {
            ITreatmentRepository repository;

            if (_source == DataSourceEnum.Database)
                repository = new TreatmentRepository();
            else
                repository = new TreatmentApiRepository();

            return new TreatmentFacade(repository);
        }

        public TreatmentOnAppointmentFacade GeTreatmentOnAppointmentFacade()
        {
            ITreatmentOnAppointmentRepository repository;

            if (_source == DataSourceEnum.Database)
                repository = new TreatmentOnAppointmentRepository();
            else
                repository = new TreatmentOnAppointmentApiRepository();

            return new TreatmentOnAppointmentFacade(repository);
        }
    }
}