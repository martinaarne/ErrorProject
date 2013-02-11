using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ErrorProject.Models
{
    public class ViewModel
    {
        private Error _error;
        private List<Comment> _comments;

        public Error Error
        {
            get { return _error; }
            set { _error = value; }
        }

        public List<Comment> Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }
    }
}