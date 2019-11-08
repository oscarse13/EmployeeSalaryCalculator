# EmployeeSalaryCalculator
Descripción: Employee Salary Calculator Test
Web API: Asp.Net Core 3.0
Frontend: Web ASP.NET Core app con React

En el archivo appsettings.json del proyecto EmployeeSalaryCalculator se encuentra la url del API "https://localhost:44354/api/Employee/", la cual sirve para acceder a los dos endpoints creados para obtener uno o todos los empleados.
Para acceder a esta variable del appsettings.json se utilizó el paquete read-appsettings-json, cuando se haga la instalación por favor actualizar en el archivo node_modules\read-appsettings-json\dist\index.js
la siguiente linea: AppConfiguration.json = require('../../../appsettings.json'); por : AppConfiguration.json = require('../../../../appsettings.json');
Esta modificación se hace para poder apuntar correctamente a la ruta que contiene el archivo requerido.


Como no se entrego una fuente de datos (API nombrado en el ejercicio), se creo una DB llamada EmployeeDB en el localhost (utilizar el script EmployeeSalaryCalculator.Data/DB/DB Script.sql para crear la DB localmente con un para de datos semilla para pruebas)
Para actualizar el nombre del servidor donde se despliegue la DB por favor modificar el valor de la variable DBServer en el archivo appsettings.json del proyecto EmployeeSalaryCalculator.Api

Cualquier duda o problema con la ejecución del proyecto por favor comunicarse a oscarse@gmail.com

Gracias,
