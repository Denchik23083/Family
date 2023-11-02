using Family.WebDb.UsersRepository.GodRepository;

namespace Family.Logic.UsersService.GodService
{
    public class GodService : IGodService
    {
        private readonly IGodRepository _repository;

        public GodService(IGodRepository repository)
        {
            _repository = repository;
        }
    }
}
