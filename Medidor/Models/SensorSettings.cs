using System.Collections.Generic;

namespace Medidor.Models
{
    public class SensorSettings
    {

        /*
            The Server  IP address where the data should be stored and where the User Interface System is installed
            O Endereço IP do servidor onde os dados devem ser armazenados e onde está instalado o sistema de Insterface de Usuario
         */
        public string ServersIP { get; set; }

        /*
            The calibration parameter list: Contains the calibration parameters used as coefficients in the linear regression polynomial that converts the data  "raw " into physical quantities
            The calibration parameter list: Contains the calibration parameters used as coefficients in the linear regression polynomial that converts the data  "RAW " into physical quantities.
            The length of the list specifies the order of polynomial. The elements of the list are the coefficients. The n-th element is the coefficient of order n. The 0-th element is the zero-order coefficient
            A lista de parâmetros de calibração: contém os parâmetros de calibração usados como coeficientes no polinômio de regressão linear que converte os dados  "RAW " em quantidades físicas
            A lista de parâmetros de calibração: contém os parâmetros de calibração usados como coeficientes no polinômio de regressão linear que converte os dados  "RAW " em quantidades físicas.
        O comprimento da lista especifica a ordem de polinômio. Os elementos da lista são os coeficientes. O N-ésimo elemento é o coeficiente da ordem N. O elemento 0-ésimo é o coeficiente de ordem zero
         */
        public List<double> CalibrationParameters {get;set;}
        
        /*
            can be 1 - "flow rate", in Hertz due to the nature of the leakage meter used
            can be 2 - voltage, in floating point due to the nature of the Arduino voltage meter that I am trying to simulate

            pode ser 1 - vazao, medida em Hertz devido a natureza do medidor de vazao utilizado
            pode ser 2 - tensao, captada em ponto flutuante devido a natureza do medidor de tensao do arduino que estou tentando simular
         */

        public int  OperationType { get; set; }

        /*
            Hardware ID - Specifies the arduino's identification configured by the user logged on server
            Hardware ID - Especifica a identificação do Arduino configurada pelo usuário conectado no servidor
         */
        public string HWID { get; set; }

        /*
            Hardware IP - Store the Arduino's IP address obtainded by DHCP
            Hardware IP - Armazena o enderço IP do Arduino obtido via DHCP
         */
        public string HWIP { get; set; }
         /*
            State - The operation state of sensor: on(1), off(0) or calibrate(2)
            State - O estado de operacao do sensor: on(1), off(0) or calibrate(2)
         */
         public int State { get; set; }
    }
}