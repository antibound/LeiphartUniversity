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
                int digit = random.Next(0, 9);
                if (digit != 0)
                {
                    newId.Append(digit);
                }
                else {
                    --i;
                }
            }

            return long.Parse(newId.ToString());
        }
    }
}