using AutoMapper;
using backend.Application.Models;
using backend.DataAccess.Entities;
using backend.DataAccess.Repository;

namespace backend.Application.Services.Impl
{
    public class SubscriberService : ISubscriberService
    {
        private readonly IRepository<Subscriber> _repository;
        private readonly IMapper _mapper;
        public SubscriberService(IRepository<Subscriber> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<SubscriberResponseModel> AddSubscriber(NewSubscriberModel model)
        {
            var subscriber = _mapper.Map<Subscriber>(model);
            subscriber.SubscriptionDate = DateTime.UtcNow;
            var subscriberResponse = await _repository.CreateAsync(subscriber);
            return _mapper.Map<SubscriberResponseModel>(subscriberResponse);
        }

        public async Task<SubscriberResponseModel> DeleteSubscriberById(Guid id)
        {
            return _mapper.Map<SubscriberResponseModel>(await _repository.DeleteByGuidAsync(id));
        }

        public async Task<SubscriberResponseModel> DeleteSusbcriberByEmail(string email)
        {
            return _mapper.Map<SubscriberResponseModel>(await _repository.DeleteByAStringAsync(email));
        }

        public async Task<SubscriberResponseModel> GetSubscriberByEmail(string email)
        {
            return _mapper.Map<SubscriberResponseModel>(await _repository.GetByStringAsync(email));
        }

        public async Task<SubscriberResponseModel> GetSubscriberById(Guid id)
        {
            return _mapper.Map<SubscriberResponseModel>(await _repository.GetByGuidAsync(id));
        }

        public async Task<IEnumerable<SubscriberResponseModel>> GetSubscribers()
        {
            return _mapper.Map<IEnumerable<SubscriberResponseModel>>(await _repository.GetAllAsync());
        }

        public async Task<SubscriberStatsModel> GetSubscriberStats()
        {

            var subscribers = await _repository.GetAllAsync();
            return new SubscriberStatsModel
            {
                SubscribedLast24H = subscribers.Where(x => DateTime.UtcNow.Subtract(x.SubscriptionDate).TotalHours <= 24).Count(),
                SubscribedLast7D = subscribers.Where(x => DateTime.UtcNow.Subtract(x.SubscriptionDate).TotalDays <= 7).Count(),
                PercentageSubscribersWithPhoneNumber = (double)subscribers.Where(x => x.PhoneNumber != null && x.PhoneNumber != string.Empty).Count() / (double)subscribers.Count() * 100.0

            };

        }
    }
}
