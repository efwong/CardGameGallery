using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLibrary
{
    public interface IGame
    {
        IEnumerable<Player> GetWinner();
    }
}
