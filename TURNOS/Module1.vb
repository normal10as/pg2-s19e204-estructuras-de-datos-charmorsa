Module Module1
    Private turnos As New Queue
    Private nombre, turno As String
    Sub Main()
        Call carga_clientes()
        Call turnos_clientes()
    End Sub

    Sub carga_clientes()
        Do
            Console.Write("Ingrese nombre del cliente: ")
            nombre = Console.ReadLine()
            If nombre <> "" Then
                turnos.Enqueue(nombre)
            End If
        Loop Until (nombre = "")
    End Sub

    Sub turnos_clientes()
        For x = 0 To (turnos.Count - 1)
            Console.Write("oprima cualquier tecla para continuar: ")
            turno = Console.ReadLine()
            Console.WriteLine()
            Console.WriteLine("el siguiente turno es de --{0}--", turnos.Dequeue)
            Console.WriteLine()
            Console.WriteLine("cantidad de clientes en espera: {0}", turnos.Count)
            Console.WriteLine()
            Console.WriteLine("---------------------------------------------------")
        Next
    End Sub
End Module
