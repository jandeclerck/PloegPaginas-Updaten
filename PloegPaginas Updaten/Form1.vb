Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQL As String = "SELECT Ploeg.PloegOrde, Ploeg.PloegNaam, Ploeg.ID FROM(Ploeg) WHERE ((Ploeg.actief)=Yes) ORDER BY Ploeg.PloegOrde "
        Dim cn As New OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=S:\basket\Wordpressprogramma\wordpress.mdb")
        Dim dt As New DataTable()
        Dim da As New OleDbDataAdapter()
        cn.Open()
        da.SelectCommand = New OleDbCommand((SQL), cn)
        da.Fill(dt)
        PloegenCmb.DataSource = dt
        PloegenCmb.DisplayMember = "PloegNaam"
        PloegenCmb.ValueMember = "ID"
        cn.Close()
    End Sub
    Private Sub MaakPaginaCode()
        TextBox1.Text = ""
        Dim SqlCom As OleDbCommand
        Dim cn As New OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=S:\basket\Wordpressprogramma\wordpress.mdb")
        Dim PloegID As Long = PloegenCmb.SelectedValue
        Dim Dr As OleDbDataReader
        Dim PloegNaam As String
        Dim Reeks As String
        Dim SponsorID As Long
        Dim WPLayerSliderID As Long
        Dim VBLGuid As String
        Dim WPPloegPage As Long
        Dim TrainingsUren As String
        Dim FlickerSetID As String
        Dim Foto As String
        Dim SponsorEMail As String
        Dim SponsorWebsite As String
        Dim Sponsor As String
        Dim SponsorKort As String

        Dim Sb As New System.Text.StringBuilder


        Try
            cn.Open()
            'Inlezen Ploeg Info
            SqlCom = New OleDbCommand("SELECT Ploeg.ID, Ploeg.PloegNaam, Ploeg.Reeks, Ploeg.SponsorID, Ploeg.WPLayerSliderID, Ploeg.VBLGuid, Ploeg.WPPloegPage, Ploeg.Trainingsuren, Ploeg.FlickerSetID, Ploeg.Foto FROM Ploeg WHERE (((Ploeg.ID)=[@PLID]))", cn)
            SqlCom.Parameters.AddWithValue("@PLID", PloegID)
            Dr = SqlCom.ExecuteReader
            If Not Dr.HasRows Then
                Beep()
                MsgBox("Geen ploeg gevonden!")
                cn.Close()
                Exit Sub
            End If
            Dr.Read()
            PloegNaam = Dr("PloegNaam")
            Reeks = Dr("Reeks")
            SponsorID = Dr("SponsorID")
            WPLayerSliderID = Dr("WPLayerSliderID")
            VBLGuid = Dr("VBLGUID")
            WPPloegPage = Dr("WPPloegPage")
            PaginaIDlbl.Text = WPPloegPage.ToString
            TrainingsUren = Dr("TrainingsUren")
            FlickerSetID = Dr("FlickerSetID")
            Foto = Dr("Foto")
            'Inlezen sponsorinfo
            SqlCom = New OleDbCommand("SELECT Gegevens.GegID, Gegevens.Titel, Gegevens.Adres, Gegevens.Postnummer, Gegevens.Gemeente, Gegevens.[Telefoon Zaak], Gegevens.Website, Gegevens.PubliekEmail
FROM Ploeg LEFT JOIN Gegevens ON Ploeg.SponsorID = Gegevens.GEGID
WHERE (((Ploeg.ID)=[@PLID]))", cn)
            SqlCom.Parameters.AddWithValue("@PLID", PloegID)
            Dr = SqlCom.ExecuteReader
            If Not Dr.HasRows Then
                Beep()
                MsgBox("Geen sponsor gevonden!")
                cn.Close()
                Exit Sub
            End If
            Dr.Read()
            Sb.AppendLine(Dr("Titel"))
            Sb.AppendLine(Dr("Adres"))
            Sb.Append(Dr("Postnummer"))
            Sb.Append(" ")
            Sb.AppendLine(Dr("Gemeente"))
            Sb.Append("Tel:")
            Sb.Append(Dr("Telefoon Zaak"))
            Sponsor = Sb.ToString
            Sb.Clear()
            'SponsorEMail = Dr("PubliekEmail")
            If IsDBNull(Dr("Website")) Then SponsorWebsite = "http://kbbco.be/" Else SponsorWebsite = Dr("Website")
            SponsorID = Dr("GegID")
            SponsorKort = Dr("Titel")
            'Start Stringbuilding alle " staan dubbel=enkel in output
            With Sb
                .Append("[layerslider id=""")
                .Append(WPLayerSliderID.ToString)
                .AppendLine("""]")
                .AppendLine()
                .AppendLine("[tabby title=""Ploeg""]")
                .AppendLine()
                .AppendLine("[bscolumns class=""one_third""]")

                ' Spelers inlezen
                SqlCom = New OleDbCommand("SELECT Medewerkers.Naam, Medewerkers.Voornaam, Medewerkers.Geboorte
FROM (Medewerkers RIGHT JOIN T_Groep ON Medewerkers.IDMW = T_Groep.IDMW) LEFT JOIN Ploeg ON T_Groep.IDPL = Ploeg.ID
WHERE (((Ploeg.ID)=[@PLID]) AND ((Medewerkers.[Niet Aktief])=No) AND ((T_Groep.IDTI)=11))
ORDER BY Medewerkers.Naam, Medewerkers.Voornaam", cn)
                SqlCom.Parameters.AddWithValue("@PLID", PloegID)
                Dr = SqlCom.ExecuteReader
                If Dr.HasRows Then
                    .AppendLine("<h4>Spelers</h4>")
                    Do While Dr.Read
                        .Append(Dr("Naam"))
                        .Append(" ")
                        .Append(Dr("Voornaam"))
                        If IsDBNull(Dr("Geboorte")) Then
                            .AppendLine()
                        Else
                            .Append("(")
                            .Append(Year(Dr("Geboorte")).ToString)
                            .AppendLine(")")
                        End If
                    Loop
                End If
                .AppendLine("[/bscolumns]")
                .AppendLine()
                .AppendLine("[bscolumns class=""one_third""]")
                .AppendLine("<h4>Medewerkers</h4>")
                'Andere medewerkers inlezen
                SqlCom = New OleDbCommand("SELECT Medewerkers.Naam, Medewerkers.Voornaam, TitelOmschrijving.Titel
FROM ((Medewerkers RIGHT JOIN T_Groep ON Medewerkers.IDMW = T_Groep.IDMW) LEFT JOIN Ploeg ON T_Groep.IDPL = Ploeg.ID) INNER JOIN TitelOmschrijving ON T_Groep.IDTI = TitelOmschrijving.IDTI
WHERE (((Ploeg.ID)=[@PLID]) AND ((Medewerkers.[Niet Aktief])=No) AND ((T_Groep.IDTI)<>11))
ORDER BY TitelOmschrijving.TitelOrde, Medewerkers.Naam, Medewerkers.Voornaam", cn)
                SqlCom.Parameters.AddWithValue("@PLID", PloegID)
                Dr = SqlCom.ExecuteReader
                Dim VorigeTitel As String = ""
                If Dr.HasRows Then
                    Do While Dr.Read
                        If Dr("Titel") <> VorigeTitel Then
                            'Nieuw kop titel
                            .Append("<h6>")
                            .Append(Dr("Titel"))
                            .AppendLine("</h6>")
                            VorigeTitel = Dr("Titel")
                        End If
                        .Append(Dr("Naam"))
                        .Append(" ")
                        .AppendLine(Dr("Voornaam"))
                    Loop
                End If
                .AppendLine("[/bscolumns]")
                .AppendLine()
                .AppendLine("[bscolumns class=""one_third_last""]")
                .AppendLine("<h4>Ploegsponsor</h4>")
                'Reclame inlezen om hoogte en breedt te bepalen
                Dim tClient As New System.Net.WebClient
                Dim ReclameUrl As String = "http://kbbco.be/wp-content/Sponsorlogos/" + SponsorID.ToString + ".jpg"
                Dim tImage As Bitmap = Bitmap.FromStream(New System.IO.MemoryStream(tClient.DownloadData(ReclameUrl)))
                Dim width As Integer = tImage.Width
                Dim height As Integer = tImage.Height
                tImage.Dispose()
                .Append("<a href=""")
                .Append(SponsorWebsite)
                .Append("""")
                .Append("><img class=""alignnone size-full wp-image-2489"" src=""/wp-content/Sponsorlogos/")
                .Append(SponsorID.ToString)
                .Append(".jpg"" alt=""")
                .Append(SponsorKort)
                .Append(""" width=""")
                .Append(width.ToString)
                .Append(""" height=""")
                .Append(height.ToString)
                .AppendLine(""" /></a>")
                .AppendLine()
                .AppendLine(Sponsor)
                .Append("<a href=""")
                .Append(SponsorWebsite)
                .AppendLine(""">Bezoek Website Sponsor </a>")
                '.Append("<a href=""mailto:")
                '.Append(SponsorEMail)
                '.Append("?subject=Vraag via KBBCO.be")
                '.Append(""">")
                ' .AppendLine("Mail Sponsor </a>")
                .AppendLine()
                .AppendLine("[/bscolumns]")
                .AppendLine()
                If VBLGuid <> "nihil" Then
                    .AppendLine("[tabby title=""Kalender""]")
                    .Append("[kalender guid=""")
                    .Append(VBLGuid)
                    .Append(""" naam=""")
                    .Append(PloegNaam)
                    .AppendLine("""]")
                    .AppendLine()
                    .AppendLine("[tabby title=""Klassement""]")
                    .Append("[klassement guid=""")
                    .Append(VBLGuid)
                    .Append(""" naam=""")
                    .Append(PloegNaam)
                    .AppendLine("""]")
                    .AppendLine()
                End If
                .AppendLine("[tabby title=""Verslagen""]")
                .AppendLine("[catlist categorypage=""yes"" tags=""verslag""]")
                .AppendLine()
                .AppendLine("[tabby title=""Ploegfoto""]")
                .Append("<img src=""http://kbbco.be/wp-content/PloegFotos/")
                .Append(Foto)
                .AppendLine(".jpg"" alt=""Ploegfoto"" />")
                .AppendLine()
                .AppendLine("[tabby title=""Trainingsuren""]")
                .AppendLine()
                .AppendLine(TrainingsUren)
                .AppendLine("[tabby title=""Foto's""]")
                .Append("<div style=""position: relative; padding-bottom: 101%; height: 0; overflow: hidden;""><iframe id=""iframe"" style=""width: 100%; height: 100%; position: absolute; top: 0; left: 0;"" src=""http://flickrit.com/slideshowholder.php?height=100&amp;size=big&amp;count=100&amp;setId=")
                .Append(FlickerSetID.ToString)
                .AppendLine("&amp;click=true&amp;thumbnails=1&amp;transition=0&amp;layoutType=responsive&amp;sort=0"" width=""300"" height=""150"" frameborder=""0"" scrolling=""no""></iframe></div>")
                .AppendLine("[tabbyending]")

            End With


            TextBox1.Text = Sb.ToString
            cn.Close()


        Catch ex As Exception
            MsgBox(ex.ToString)
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try


    End Sub

    Private Sub MaakPaginaCodeBtn_Click(sender As Object, e As EventArgs) Handles MaakPaginaCodeBtn.Click
        MaakPaginaCode()
    End Sub

    Private Sub CopyBtn_Click(sender As Object, e As EventArgs) Handles CopyBtn.Click
        Clipboard.SetText(TextBox1.Text)
    End Sub
    Private Sub SchrijfNaarWordPress()
        Dim MySqlConn As New MySqlConnection
        MySqlConn.ConnectionString = "server=mysql038.hosting.combell.com; user=ID147483_wpress; password=p6dVNY6r; database=ID147483_wpress"
        MySqlConn.Open()
        Dim mscomm As New MySqlCommand("UPDATE wp_posts SET wp_posts.post_content = @post_content
WHERE (((wp_posts.ID)=@PostID));", MySqlConn)

        mscomm.Parameters.AddWithValue("@PostID", PaginaIDlbl.Text)
        mscomm.Parameters.AddWithValue("@post_content", TextBox1.Text)
        Dim i As Integer = mscomm.ExecuteNonQuery()
        If i = 1 Then Beep() Else MsgBox("Fout:" + i.ToString + " Rijen aangepast in database")


        MySqlConn.Close()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Process.Start("http://kbbco.be/?page_id=" + PaginaIDlbl.Text)
    End Sub

    Private Sub PloegenCmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PloegenCmb.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        For i = 0 To PloegenCmb.Items.Count - 1
            PloegenCmb.SelectedIndex = i
            MaakPaginaCode()
            SchrijfNaarWordPress()
        Next
    End Sub

    Private Sub SchrijfNaarWordPressBtn_Click(sender As Object, e As EventArgs) Handles SchrijfNaarWordPressBtn.Click
        SchrijfNaarWordPress()
    End Sub
End Class
