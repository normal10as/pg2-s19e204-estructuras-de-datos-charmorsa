Module Module1

    Sub Main()
        Dim codigo(9), cantidad(9) As Integer
        Dim nombre(9), venta(9) As String
        Dim precio(9), total(9) As Decimal
        codigo(0) = 1
        codigo(1) = 2
        codigo(2) = 3
        codigo(3) = 4
        codigo(4) = 5
        codigo(5) = 6
        codigo(6) = 7
        codigo(7) = 8
        codigo(8) = 9
        nombre(0) = "pure de tomate"
        nombre(1) = "manzana"
        nombre(2) = "arroz"
        nombre(3) = "cerveza"
        nombre(4) = "pepsi"
        nombre(5) = "helado"
        nombre(6) = "azucar"
        nombre(7) = "chorizo"
        nombre(8) = "queso"
        precio(0) = 25.6
        precio(1) = 2.0
        precio(2) = 35.0
        precio(3) = 60.33
        precio(4) = 35.5
        precio(5) = 20.0
        precio(6) = 22.49
        precio(7) = 120.0
        precio(8) = 40.0
        Call busqueda(codigo, nombre, precio, cantidad, venta, total)
        Console.WriteLine("El total a Pagar es de ${0} ", resultado(total))
    End Sub

    Sub busqueda(ByRef cod() As Integer, ByVal nom() As String, ByRef pre() As Decimal, ByRef cant() As Integer, ByRef vent() As String, ByRef tot() As Decimal)
        Dim bus, x As Integer
        x = 0
        Console.WriteLine("-------------BUSQUEDA DE PRODUCTOS-------------")
        Do
            Console.Write("ingresar un codigo...para finalizar la venta ingrese un cero '0'...")
            bus = Console.ReadLine()
            If bus <> 0 Then
                If existe(cod, bus) = -1 Then
                    Console.WriteLine("el codigo ingresado no existe...")
                Else
                    Console.WriteLine("----el codigo {0} posee el producto {1} con el precio {2} ----", cod(existe(cod, bus)), nom(existe(cod, bus)), pre(existe(cod, bus)))
                    Console.Write("cantidad= ")
                    cant(x) = Console.ReadLine()
                    vent(x) = nom(existe(cod, bus))
                    tot(x) = Convert.ToDecimal(cant(x)) * pre(existe(cod, bus))
                    x += 1
                End If
            End If
        Loop Until bus = 0
    End Sub

    Function existe(ByRef c() As Integer, ByRef b As Integer) As Integer
        Dim i As Integer = 0
        Do
            If b = c(i) Then
                Return i
            End If
            i += 1
        Loop Until i = c.Length
        Return -1
    End Function

    Function resultado(ByRef tota() As Decimal) As Decimal
        Dim resu As Decimal
        For i As Integer = 0 To tota.Length - 1
            resu += tota(i)
        Next
        Return resu
    End Function
End Module
