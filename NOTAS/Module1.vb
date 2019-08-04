Module Module1
    Private a, b, c As Integer
    Private inteligentes(1) As String
    Sub Main()
        Dim alumnos(40) As String
        Dim notas(40, 4) As Byte
        Call carga(alumnos, notas)
        Call informe(alumnos, notas)
        Call mejores()
    End Sub
    Sub carga(ByRef alu() As String, ByRef nota(,) As Byte)
        Dim i, x As Integer
        Console.Write("INGRESE LA CANTIDAD DE ALUMNOS: ")
        a = Console.ReadLine()
        Console.Write("INGRESE LA CANTIDAD DE NOTAS DEL ALUMNO: ")
        b = Console.ReadLine()
        i = 0
        Do
            Console.Write("INGRESE EL NOMBRE DEL ALUMNO: ")
            alu(i) = Console.ReadLine()
            If Len(alu(i)) > 2 Then
                If ((existe(alu, i) = True) Or (i = 0)) Then
                    x = 0
                    Do
                        Console.Write("NOTA {0}= ", x + 1)
                        nota(i, x) = Console.ReadLine()
                    Loop Until rango(nota, i, x) = b
                End If
                i += 1
            Else
                Console.WriteLine("el nombre del alumno debe tener almenos 3 caracteres...")
            End If
        Loop Until i = a
    End Sub
    Sub informe(ByVal alum() As String, ByVal nota(,) As Byte)
        Dim promedio(a) As Byte
        Dim x, i As Integer
        i = 0
        Do
            x = 0
            Do
                promedio(i) += nota(i, x)
                x += 1
            Loop Until x = b
            promedio(i) /= b
            Console.WriteLine("alumno: '{0}' con un promedio de {1} {2}", alum(i), promedio(i), rinde(promedio, i))
            i += 1
        Loop Until i = a
        Console.WriteLine("EL/LA ALUMNO/A CON MEJOR PROMEDIOS ES {0}", alum(mejor(promedio, alum)))
    End Sub
    Function existe(ByRef alumno() As String, ByRef aux As Integer) As Boolean
        Dim ex As Boolean
        For i As Integer = 0 To i = a
            If alumno(i) = alumno(aux) Then
                ex = False
            Else
                ex = True
            End If
        Next
        Return ex
    End Function
    Function mejor(ByVal pro() As Byte, ByRef alu() As String) As Byte
        Dim m As Byte = 0
        Dim pos As Byte = 0
        Dim i As Integer = 0
        c = 0
        Do
            If pro(i) > m Then
                m = pro(i)
                pos = i
                inteligentes(c) = alu(pos)
            ElseIf pro(i) = m Then
                m = i
                c += 1
                ReDim Preserve inteligentes(c)
                inteligentes(c) = alu(i)
            End If
            i += 1
        Loop Until i = a
        Return pos
    End Function
    Function rango(ByVal n(,) As Byte, ByVal y As Integer, ByRef z As Integer) As Integer
        If (n(y, z) < 11 And n(y, z) > 0) Then
            z += 1
        Else
            Console.Write("la nota ingresada es incorrecta...")
            Console.WriteLine("ingrese nuevamente la nota...")
        End If
        Return z
    End Function
    Function rinde(ByVal p() As Byte, ByVal q As Integer) As String
        If p(q) > 5 Then
            Return "APROBO!"
        End If
        Return "DESAPROBO!"
    End Function
    Sub mejores()
        Console.WriteLine("los mejores alumnos son: ")
        For i As Integer = 0 To inteligentes.Length
            Console.WriteLine(inteligentes(i))
        Next
    End Sub
End Module
