Module Module1

    Private domipais As New Collection
    Sub Main()
        domipais.Add("Argentina", "arg")
        domipais.Add("Paraguay", "par")
        domipais.Add("Bolivia", "bol")
        domipais.Add("Chile", "chi")
        domipais.Add("Brasil", "bra")
        domipais.Add("Uruguay", "urg")
        domipais.Add("Ecuador", "ecu")
        domipais.Add("Peru", "per")
        domipais.Add("Colombia", "col")
        domipais.Add("Venezuela", "ven")
        domipais.Add("Panama", "pan")
        domipais.Add("Honduras", "hon")
        Call busqueda()
    End Sub

    Sub busqueda()
        Dim dominio As String
        Do
            Console.Write("INGRESE UN CODIGO DE DOMINIO. EJ: urg (Uruguay)...")
            dominio = Console.ReadLine()
            For Each cod In domipais
                If domipais.Contains(dominio) Then
                    Console.WriteLine("El Pais es '{0}' ", domipais(dominio))
                    Exit For
                ElseIf dominio = "" Then
                    Console.WriteLine("fin")
                    Exit Do
                Else
                    Console.WriteLine("No existe ese dominio.")
                    Exit For
                End If
            Next
        Loop While dominio <> ""
    End Sub
End Module
