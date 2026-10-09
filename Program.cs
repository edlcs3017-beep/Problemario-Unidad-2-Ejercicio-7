// Se solicitan los tiempos de cada etapa en segundos.
Console.Write("Introduce el tiempo para tomar la pieza (s): ");
double tiempoTomar = Convert.ToDouble(Console.ReadLine());

Console.Write("Introduce el tiempo para trasladar la pieza (s): ");
double tiempoTrasladar = Convert.ToDouble(Console.ReadLine());

Console.Write("Introduce el tiempo para soltar la pieza (s): ");
double tiempoSoltar = Convert.ToDouble(Console.ReadLine());

// Se solicita el número de ciclos a simular.
Console.Write("Introduce el número de ciclos a simular: ");
int numCiclos = Convert.ToInt32(Console.ReadLine());

// Se validan los datos ingresados.
if (tiempoTomar < 0 || tiempoTrasladar < 0 || tiempoSoltar < 0 || numCiclos <= 0)
{
    Console.WriteLine("Error: Los tiempos no pueden ser negativos y el número de ciclos debe ser mayor a cero.");
}
else
{
    // OBJETO: se crea una instancia de la clase BrazoRobotico.
    BrazoRobotico robot = new BrazoRobotico();

    // PROPIEDADES: se asignan los tiempos ingresados.
    robot.TiempoTomar = tiempoTomar;
    robot.TiempoTrasladar = tiempoTrasladar;
    robot.TiempoSoltar = tiempoSoltar;

    // Se ejecuta la simulación.
    robot.SimularCiclos(numCiclos);
}

// CLASE: representa el brazo robótico.
class BrazoRobotico
{
    // PROPIEDADES: almacenan los tiempos de cada etapa en segundos.
    public double TiempoTomar { get; set; }
    public double TiempoTrasladar { get; set; }
    public double TiempoSoltar { get; set; }

    // MÉTODO: calcula el tiempo total de un solo ciclo.
    public double CalcularTiempoCiclo()
    {
        return TiempoTomar + TiempoTrasladar + TiempoSoltar;
    }

    // MÉTODO: simula las repeticiones y muestra el tiempo acumulado.
    public void SimularCiclos(int numCiclos)
    {
        double tiempoPorCiclo = CalcularTiempoCiclo();
        double tiempoAcumulado = 0;

        Console.WriteLine($"\nTiempo por ciclo: {tiempoPorCiclo:F2} s\n");

        // CICLO FOR: muestra el tiempo acumulado tras cada repetición.
        for (int i = 1; i <= numCiclos; i++)
        {
            tiempoAcumulado += tiempoPorCiclo;
            Console.WriteLine($"Ciclo {i}: Tiempo acumulado = {tiempoAcumulado:F2} s");
        }

        // Se muestra el tiempo total de producción.
        Console.WriteLine($"\nTiempo total de producción: {tiempoAcumulado:F2} s");
    }
}