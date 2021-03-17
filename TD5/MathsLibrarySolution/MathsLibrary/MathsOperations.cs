using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MathsLibrary
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class MathsOperations : IMathsOperations
    {
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        public double Divide(int number1, int number2)
        {
            if(number2 == 0)
            {
                return 0;
            }else
            {
                return number1 / number2;
            }
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }

        public int Subtract(int number1, int number2)
        {
            return number1 - number2;
        }
    }
}
