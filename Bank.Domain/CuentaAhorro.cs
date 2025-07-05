namespace Bank.Domain
{
    public class CuentaAhorro
    {
        public const string ERROR_MONTO_MENOR_IGUAL_A_CERO = "El monto no puede ser menor o igual a 0";
        public const string ERROR_SALDO_INSUFICIENTE = "Saldo insuficiente";
        public int IdCuenta { get; private set; }
        public string NumeroCuenta { get; private set; } = string.Empty;
        public virtual Cliente Propietario { get; private set; } = null!;
        public int IdPropietario { get; private set; }
        public decimal Tasa { get; private set; }
        public decimal Saldo { get; private set; }
        public DateTime FechaApertura { get; private set; }
        public bool Estado { get; private set; }
        
        public static CuentaAhorro Aperturar(string _numeroCuenta, Cliente _propietario, decimal _tasa)
        {
            if (string.IsNullOrEmpty(_numeroCuenta))
                throw new ArgumentException("El número de cuenta no puede ser nulo o vacío", nameof(_numeroCuenta));
            if (_propietario == null)
                throw new ArgumentNullException(nameof(_propietario));

            return new CuentaAhorro()
            {
                NumeroCuenta = _numeroCuenta,
                Propietario = _propietario,
                IdPropietario = _propietario.IdCliente,
                Tasa = _tasa,
                Saldo = 0,
                FechaApertura = DateTime.Now,
                Estado = true
            };
        }     
        public void Depositar(decimal monto)
        {
            if (monto <= 0)
                throw new Exception (ERROR_MONTO_MENOR_IGUAL_A_CERO);
            Saldo += monto;
        }
        public void Retirar(decimal monto)
        {
            if (monto <= 0)
                throw new Exception (ERROR_MONTO_MENOR_IGUAL_A_CERO);
            if (monto > Saldo)
                throw new Exception (ERROR_SALDO_INSUFICIENTE);
            Saldo -= monto;
        }
    }
}