// ============================================================================
//  Program.cs este UTILIZATORUL clasei OvenController.
//  După refactorizare, aici (și numai aici) se creează obiectele:
//  OvenController primește un notificator, iar în laborator folosim
//  ConsoleNotifier, nu SMS-uri reale.
//
//  Rezultat așteptat: DOUĂ alarme, la 251 °C și la 255 °C.
// ============================================================================
using OvenAlarm;

OvenController oven = new(new SmsNotifier("123456789"));   // de modificat: notificatorul se primește din exterior

double[] readings = { 200, 251, 260, 245, 235, 255 };

foreach (double t in readings)
{
    Console.WriteLine($"T = {t} °C");
    oven.Check(t);
}
