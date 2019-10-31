using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class PublisherManager : IPublisherService
    {
        private IPublisherDal _publisherDal;

        public PublisherManager(IPublisherDal publisherDal)
        {
            _publisherDal = publisherDal;
        }

        public IDataResult<List<Publisher>> GetPublishers()
        {
            return new SuccessDataResult<List<Publisher>>(_publisherDal.GetList().ToList());
        }
    }
}
