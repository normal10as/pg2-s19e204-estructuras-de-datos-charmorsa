Module Module1
    Private total_empleado As New SortedList(Of String, Single)
    Private domingo, lunes, martes, miercoles, jueves, viernes, sabado As New List(Of Single)
    Private empleados As New SortedList(Of String, String)
    Private produccion As New SortedList(Of String, String)
    Private precios As New SortedList(Of String, Single)
    Sub Main()
        Call carga_productos()
        Call carga_precio()
        Call carga_empelados()
        Call informe()
    End Sub

    Sub carga_productos()
        produccion.Add("c01", "Cabure")
        produccion.Add("c02", "Chipa")
        produccion.Add("c03", "Sopa Paraguaya")
        produccion.Add("c04", "JAMON Y QUESO")
    End Sub

    Sub carga_precio()
        precios.Add("Cabure", 25)
        precios.Add("Chipa", 15)
        precios.Add("Sopa Paraguaya", 35)
        precios.Add("JAMON Y QUESO", 20)
    End Sub

    Sub carga_empelados()
        empleados.Add("hcj", "HERRERA Carlos Javier")
        empleados.Add("bnv", "BUCHER Nathalie Valeria")
        empleados.Add("mjm", "MAIDANA Juan Manuhel")
        empleados.Add("jsi", "JOHANSSON Scarlett Ingrid")

        total_empleado.Add("HERRERA Carlos Javier", 0)
        total_empleado.Add("BUCHER Nathalie Valeria", 0)
        total_empleado.Add("MAIDANA Juan Manuhel", 0)
        total_empleado.Add("JOHANSSON Scarlett Ingrid", 0)

    End Sub

    Function ingresar_empleado() As String
        Dim id As String
        Console.Write("Ingrese clave de empleado: ")
        id = Console.ReadLine()
        If empleados.ContainsKey(id) Then
            Return empleados.Item(id)
        Else
            Console.WriteLine("EMPLEADO INEXISTENTE...")
            Return ""
        End If
    End Function

    Sub cierre_dias(ByRef precio As Single, ByRef dia As Byte)
        Select Case dia
            Case 1
                domingo.Add(precio)
            Case 2
                lunes.Add(precio)
            Case 3
                martes.Add(precio)
            Case 4
                miercoles.Add(precio)
            Case 5
                jueves.Add(precio)
            Case 6
                viernes.Add(precio)
            Case 7
                sabado.Add(precio)
        End Select
    End Sub

    Sub cierre_empleado(ByRef empleado As String, ByRef precio As Single)
        total_empleado(empleado) += precio
    End Sub

    Function ingresar_producto() As String
        Dim id As String
        Console.Write("Ingrese id de producto: ")
        id = Console.ReadLine()
        If produccion.ContainsKey(id) Then
            Return produccion.Item(id)
            Console.Write("hols")
        Else
            Console.WriteLine("PRODUCTO INEXISTENTE")
            Return ""
        End If
    End Function

    Function cargar_precio(ByVal aux As String) As Single
        Return precios.Item(aux)
    End Function

    Function ingresar_cantidad() As UInt16
        Console.Write("Ingrese cantidad: ")
        Return Console.ReadLine()
    End Function

    Sub mostrar_total_por_dia(dia_list As List(Of Single), dia_string As String)
        Dim total_dia As Single
        For x = 0 To dia_list.Count - 1
            total_dia += dia_list.Item(x)
        Next
        Console.WriteLine("{0}: {1}", dia_string, total_dia)
    End Sub

    Sub informe()
        Dim cantidad As UInt16
        Dim precio, total As Single
        Dim dia As Byte
        Dim empleado, producto, respuesta As String
        Do
            Do
                Console.WriteLine("~~~~~~~~~~~~~~~~~")
                empleado = ingresar_empleado()
            Loop While (empleado = "")
            Do
                Console.WriteLine("~~~~~~~~~~~~~~~~~")
                producto = ingresar_producto()
            Loop While (producto = "")
            precio = cargar_precio(producto)
            cantidad = ingresar_cantidad()
            Do
                Console.WriteLine("~~~~~~~~~~~~~~~~~")
                Console.Write("Ingrese dia: ")
                dia = Console.ReadLine()
                If dia < 1 Or dia > 7 Then
                    Console.WriteLine("Error al ingresar dia")
                End If
            Loop Until (dia > 0 And dia < 8)
            cierre_dias((cantidad * precio), dia)
            cierre_empleado(empleado, (cantidad * precio))
            total += (cantidad * precio)
            Console.WriteLine("~~~~~~~~~~~~~~~~~")
            Console.Write("Desea continuar--- SI / NO  ")
            respuesta = Console.ReadLine()
        Loop Until UCase(respuesta) = "NO"

        Console.WriteLine("~~~~~~~~~~~~~~~~~")
        Console.WriteLine("Total por Empleados")

        For Each clave In empleados.Values
            Console.WriteLine("{0}: {1}", clave, total_empleado.Item(clave))
        Next

        Console.WriteLine("~~~~~~~~~~~~~~~~~")

        Console.WriteLine("Total por Dia")

        mostrar_total_por_dia(domingo, "Domingo")
        mostrar_total_por_dia(lunes, "Lunes")
        mostrar_total_por_dia(martes, "Martes")
        mostrar_total_por_dia(miercoles, "Miercoles")
        mostrar_total_por_dia(jueves, "Jueves")
        mostrar_total_por_dia(viernes, "Viernes")
        mostrar_total_por_dia(sabado, "Sabado")
    End Sub
End Module
