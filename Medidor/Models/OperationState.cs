namespace Medidor.Models
{
    public class OperationState
    {
        /*  
            can be 0, 1 or 2
            calibrate=2
            on=1 
            off=0

            to stand by, set off (0)
            to operate, set on (1)
            to calibrate the sensor, set calibrate (2)

            Pode ser 0, 1 ou 2
            calibrate=2
            on=1
            off=0
            para aguardar, coloque em off(0)
            para operar, coloque em on (1)
            para calibrar o medidor, coloque em calibrate (2)

        */
        public int State { get; set; }
    }
}