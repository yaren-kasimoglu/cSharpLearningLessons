using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loose_Coupling_Example
{
    public interface ICreditCard
    {
        string Pay(decimal amount);
    }
}
