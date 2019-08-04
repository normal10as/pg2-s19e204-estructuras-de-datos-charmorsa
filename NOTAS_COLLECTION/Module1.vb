Module Module1
    Private a, b As Integer
    Private inteligentes, alumnos As New ArrayList
    Private notas(40, 4) As Byte
    Private promedio As New ArrayList
    Sub Main()
        Call carga()
        Call informe()
        Call mejores()
    End Sub
    Sub carga()
        Dim i, x As Integer
        Dim nombre As String
        Console.Write("INGRESE LA CANTIDAD DE ALUMNOS: ")
        a = Console.ReadLine()
        Console.Write("INGRESE LA CANTIDAD DE NOTAS DEL ALUMNO: ")
        b = Console.ReadLine()
        i = 0
        Do
            Console.Write("INGRESE EL NOMBRE DEL ALUMNO: ")
            nombre = Console.ReadLine()
            If Len(nombre) > 2 Then
                If ((existe(nombre) = True) Or (i = 0)) Then
                    alumnos.Add(nombre)
                    x = 0
                    Do
                        Console.Write("NOTA {0}= ", x + 1)
                        notas(i, x) = Console.ReadLine()
                    Loop Until rango(i, x) = b
                End If
                i += 1
            Else
                Console.WriteLine("el nombre del alumno debe tener almenos 3 caracteres...")
            End If
        Loop Until i = a
    End Sub
    Sub informe()
        Dim i, x, acumu As Integer
        i = 0
        Do
            x = 0
            acumu = 0
            Do
                acumu += notas(i, x)
                x += 1
            Loop While x <> b
            acumu /= b
            promedio.Add(acumu)
            Console.WriteLine("alumno: '{0}' con un promedio de {1} {2}", alumnos(i), promedio(i), rinde(i))
            i += 1
        Loop Until i = a
        Console.WriteLine("EL/LA ALUMNO/A CON MEJOR PROMEDIOS ES {0}", alumnos(mejor()))
    End Sub
    Function existe(ByRef nom As String) As Boolean
        Dim ex As Boolean
        For Each pibes In alumnos
            If pibes = nom Then
                ex = False
            Else
                ex = True
            End If
        Next
        Return ex
    End Function
    Function mejor() As Byte
        Dim m As Byte = 0
        Dim pos As Byte = 0
        Dim i As Integer = 0
        Do
            If promedio(i) > m Then
                inteligentes.Remove(alumnos(pos))
                inteligentes.Add(alumnos(i))
                m = promedio(i)
                pos = i
            ElseIf promedio(i) = m Then
                m = i
                inteligentes.Add(alumnos(i))
            End If
            i += 1
        Loop Until i = a
        Return pos
    End Function
    Function rango(ByVal y As Integer, ByRef z As Integer) As Integer
        If (notas(y, z) < 11 And notas(y, z) > 0) Then
            z += 1
        Else
            Console.Write("la nota ingresada es incorrecta...")
            Console.WriteLine("ingrese nuevamente la nota...")
        End If
        Return z
    End Function
    Function rinde(ByRef aux As Integer) As String
        If promedio(aux) > 5 Then
            Return "APROBO!"
        End If
        Return "DESAPROBO!"
    End Function
    Sub mejores()
        Console.WriteLine("los mejores alumnos son: ")
        For Each genios In inteligentes
            Console.WriteLine(genios)
        Next
    End Sub
End Module
