namespace Bank.Domain
{
    public class Cliente
    {
        public int IdCliente { get; private set; }
        public string NombreCliente { get; private set; } = string.Empty;
        
        public static Cliente Registrar(string _nombre)
        {
            if (string.IsNullOrEmpty(_nombre))
                throw new ArgumentException("El nombre del cliente no puede ser nulo o vacío", nameof(_nombre));
                
            return new Cliente(){
                NombreCliente = _nombre
            };
        }   
    }
}