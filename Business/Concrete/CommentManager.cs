using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        [SecuredOperation("comment.add,admin")]
        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult();
        }

        public IResult Delete(Comment comment)
        {
            _commentDal.Delete(comment);
            return new SuccessResult();
        }

        public IDataResult<Comment> Get(int id)
        {
            return new SuccessDataResult<Comment>(_commentDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Comment>> GetAll()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll());
        }
    }
}
