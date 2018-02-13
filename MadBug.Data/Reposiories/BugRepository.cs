using MadBug.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadBug.Data.Reposiories
{
    public class BugRepository : BaseRepository<Bug>
    {
        public BugRepository(DataContext context) : base(context)
        {

        }
    }

}
