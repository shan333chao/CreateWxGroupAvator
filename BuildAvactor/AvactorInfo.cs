using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildAvactor
{
  public  class AvactorInfo
    {

      public string FilePath {get;set; }
      public int Width{ get; set; }
      public int  Heigh { get; set; }

      public bool IsResize { get; set; }
    }
}
