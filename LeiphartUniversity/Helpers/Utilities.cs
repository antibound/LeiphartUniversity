using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LeiphartUniversity.Helpers
{
    public class Utilities
    {
        public long GenerateUniversityId(Random random)
        {
            //Random random = new Random();
            StringBuilder newId = new StringBuilder();

            for (int i = 0; i < 10; ++i)
            {
                newId.Append(random.Next(0, 9));
            }

            return long.Parse(newId.ToString());
        }
    }
}