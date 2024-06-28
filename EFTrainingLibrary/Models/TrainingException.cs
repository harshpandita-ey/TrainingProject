using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTrainingLibrary.Models
{
    public class TrainingException : Exception
    {
        public TrainingException(string msg) : base(msg)
        {

        }
    }
}
