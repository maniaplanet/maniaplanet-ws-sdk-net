using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet.ManiaConnect
{
    public interface IPersistance
    {
        void Init();
        void Destroy();
        T GetVariable<T>(string name);
        object GetVariable(string name);
        bool SetVariable(string name, object value);
        bool DeleteVariable(string name); 
    }
}
