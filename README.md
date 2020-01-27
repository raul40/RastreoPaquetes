# RastreoPaquetes

Para agregar mas Paqueterias y Transportes, 
solamente se tienen que agregar clases concretas a la clase abstracta de Empresa y a la interfaz de ITransporte, 
ya que ambas(empresa/transporte) estan relacionadas(por un intento de patron bridge)
solo se tiene que modificar en la empresa la validacion de transporte para agregar un nuevo transporte.
El resto es practicamente igual ya que la clase abstracta de empresa ya tiene implementados los metodos de obtencion de datos,
y el nuevo transporte en su clase concreta seria adaptar el metodo para la obtencion de la información.

Basicamente las modificaciones se realizarian en las clases concretas de la Empresa(Paqueteria) y el Transporte.
