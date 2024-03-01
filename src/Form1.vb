Imports Newtonsoft.Json.Linq
Imports System.IO

Public Class Form1

    ' Variables that will store the color of the buttons (now pictureboxes (pbx))
    Private colorButton1 As Color = ColorTranslator.FromHtml("#FD6A68") ' Light Accent
    Private colorButton2 As Color = ColorTranslator.FromHtml("#FD6A68") ' Dark Accent
    Private colorButton3 As Color = ColorTranslator.FromHtml("#FFFFFF") ' Light Accent Text
    Private colorButton4 As Color = ColorTranslator.FromHtml("#EBEBEB") ' Dark Accent Text
    Private colorButton5 As Color = ColorTranslator.FromHtml("#FCFFFF") ' LightForeground
    Private colorButton6 As Color = ColorTranslator.FromHtml("#171717") ' Dark Foreground
    Private colorButton7 As Color = ColorTranslator.FromHtml("#F2F2F2") ' Light Background
    Private colorButton8 As Color = ColorTranslator.FromHtml("#000000") ' Dark Background
    Private colorButton9 As Color = ColorTranslator.FromHtml("#F2F2F2") ' Light Overlay
    Private colorButton10 As Color = ColorTranslator.FromHtml("#000000") ' Dark Overlay
    Private colorButton11 As Color = ColorTranslator.FromHtml("#3C3C43") ' Light Separator
    Private colorButton12 As Color = ColorTranslator.FromHtml("#545458") ' Dark Separator
    Private colorButton13 As Color = ColorTranslator.FromHtml("#212121") ' Light Body Text
    Private colorButton14 As Color = ColorTranslator.FromHtml("#EBEBEB") ' Dark Body Text
    Private colorButton15 As Color = ColorTranslator.FromHtml("#5F5F5F") ' Light Subtitle Text
    Private colorButton16 As Color = ColorTranslator.FromHtml("#C0C0C0") ' Dark Subtitle Text
    Private colorButton17 As Color = ColorTranslator.FromHtml("#FD6A68") ' Light Button Background
    Private colorButton18 As Color = ColorTranslator.FromHtml("#FD6A68") ' Dark Button Background
    Private colorButton19 As Color = ColorTranslator.FromHtml("#212121") ' Light Button Text
    Private colorButton20 As Color = ColorTranslator.FromHtml("#EBEBEB") ' Dark Button Text

    Private Sub OpenColorPicker(buttonNumber As Integer)

        ' Show the color dialog and get the selected color
        If cdUniversalPicker.ShowDialog() = DialogResult.OK Then
            Dim selectedColor As Color = cdUniversalPicker.Color

            ' Save the selected color based on the button number
            Select Case buttonNumber
                Case 1
                    colorButton1 = selectedColor
                    ' Set picturebox color
                    pbxlightAccent.BackColor = selectedColor
                    ' Update alpha using the nud value
                    nudLightAccentAlpha_ValueChanged(nudLightAccentAlpha, EventArgs.Empty)
                Case 2
                    colorButton2 = selectedColor
                    pbxDarkAccent.BackColor = selectedColor
                    nudDarkAccentAlpha_ValueChanged(nudDarkAccentAlpha, EventArgs.Empty)
                Case 3
                    colorButton3 = selectedColor
                    pbxLightAccentText.BackColor = selectedColor
                    nudLightAccentTextAlpha_ValueChanged(nudLightAccentTextAlpha, EventArgs.Empty)
                Case 4
                    colorButton4 = selectedColor
                    pbxDarkAccentText.BackColor = selectedColor
                    nudDarkAccentTextAlpha_ValueChanged(nudDarkAccentTextAlpha, EventArgs.Empty)
                Case 5
                    colorButton5 = selectedColor
                    pbxLightForeground.BackColor = selectedColor
                    nudLightForegroundAlpha_ValueChanged(nudLightForegroundAlpha, EventArgs.Empty)
                Case 6
                    colorButton6 = selectedColor
                    pbxDarkForeground.BackColor = selectedColor
                    nudDarkForegroundAlpha_ValueChanged(nudDarkForegroundAlpha, EventArgs.Empty)
                Case 7
                    colorButton7 = selectedColor
                    pbxLightBackground.BackColor = selectedColor
                    nudLightBackgroundAlpha_ValueChanged(nudLightBackgroundAlpha, EventArgs.Empty)
                Case 8
                    colorButton8 = selectedColor
                    pbxDarkBackground.BackColor = selectedColor
                    nudDarkBackgroundAlpha_ValueChanged(nudDarkBackgroundAlpha, EventArgs.Empty)
                Case 9
                    colorButton9 = selectedColor
                    pbxLightOverlay.BackColor = selectedColor
                    nudLightOverlayAlpha_ValueChanged(nudLightOverlayAlpha, EventArgs.Empty)
                Case 10
                    colorButton10 = selectedColor
                    pbxDarkOverlay.BackColor = selectedColor
                    nudDarkOverlayAlpha_ValueChanged(nudDarkOverlayAlpha, EventArgs.Empty)
                Case 11
                    colorButton11 = selectedColor
                    pbxLightSeparator.BackColor = selectedColor
                    nudLightSeparatorAlpha_ValueChanged(nudLightSeparatorAlpha, EventArgs.Empty)
                Case 12
                    colorButton12 = selectedColor
                    pbxDarkSeparator.BackColor = selectedColor
                    nudDarkSeparatorAlpha_ValueChanged(nudDarkSeparatorAlpha, EventArgs.Empty)
                Case 13
                    colorButton13 = selectedColor
                    pbxLightBodyText.BackColor = selectedColor
                    nudLightBodyTextAlpha_ValueChanged(nudLightBodyTextAlpha, EventArgs.Empty)
                Case 14
                    colorButton14 = selectedColor
                    pbxDarkBodyText.BackColor = selectedColor
                    nudDarkBodyTextAlpha_ValueChanged(nudDarkBodyTextAlpha, EventArgs.Empty)
                Case 15
                    colorButton15 = selectedColor
                    pbxLightSubtitleText.BackColor = selectedColor
                    nudLightSubtitleTextAlpha_ValueChanged(nudLightSubtitleTextAlpha, EventArgs.Empty)
                Case 16
                    colorButton16 = selectedColor
                    pbxDarkSubtitleText.BackColor = selectedColor
                    nudDarkSubtitleTextAlpha_ValueChanged(nudDarkSubtitleTextAlpha, EventArgs.Empty)
                Case 17
                    colorButton17 = selectedColor
                    pbxLightButtonBackground.BackColor = selectedColor
                    nudLightButtonBackgroundAlpha_ValueChanged(nudLightButtonBackgroundAlpha, EventArgs.Empty)
                Case 18
                    colorButton18 = selectedColor
                    pbxDarkButtonBackground.BackColor = selectedColor
                    nudDarkButtonBackgroundAlpha_ValueChanged(nudDarkButtonBackgroundAlpha, EventArgs.Empty)
                Case 19
                    colorButton19 = selectedColor
                    pbxLightButtonText.BackColor = selectedColor
                    nudLightButtonTextAlpha_ValueChanged(nudLightButtonTextAlpha, EventArgs.Empty)
                Case 20
                    colorButton20 = selectedColor
                    pbxDarkButtonText.BackColor = selectedColor
                    nudDarkButtonTextAlpha_ValueChanged(nudDarkButtonTextAlpha, EventArgs.Empty)
            End Select
        End If
    End Sub

    Private Function GetRGBJsonObject() As JObject

        ' Create the main RGB JSON object
        Dim jsonObject As New JObject()
        jsonObject("creator") = txtThemeCreator.Text

        ' Add sub-nests for accentColor
        Dim accentColorLight As New JObject()
        Dim accentColorDark As New JObject()
        If Not colorButton1.IsEmpty Then
            accentColorLight("red") = colorButton1.R
            accentColorLight("green") = colorButton1.G
            accentColorLight("blue") = colorButton1.B
            accentColorLight("alpha") = nudLightAccentAlpha.Value
        End If
        If Not colorButton2.IsEmpty Then
            accentColorDark("red") = colorButton2.R
            accentColorDark("green") = colorButton2.G
            accentColorDark("blue") = colorButton2.B
            accentColorDark("alpha") = nudDarkAccentAlpha.Value
        End If
        jsonObject("accentColor") = New JObject()
        jsonObject("accentColor")("lightColor") = accentColorLight
        jsonObject("accentColor")("darkColor") = accentColorDark

        ' Add sub-nests for accentTextColor
        Dim accentTextColorLight As New JObject()
        Dim accentTextColorDark As New JObject()
        If Not colorButton3.IsEmpty Then
            accentTextColorLight("red") = colorButton3.R
            accentTextColorLight("green") = colorButton3.G
            accentTextColorLight("blue") = colorButton3.B
            accentTextColorLight("alpha") = nudLightAccentTextAlpha.Value
        End If
        If Not colorButton4.IsEmpty Then
            accentTextColorDark("red") = colorButton4.R
            accentTextColorDark("green") = colorButton4.G
            accentTextColorDark("blue") = colorButton4.B
            accentTextColorDark("alpha") = nudDarkAccentTextAlpha.Value
        End If
        jsonObject("accentTextColor") = New JObject()
        jsonObject("accentTextColor")("lightColor") = accentTextColorLight
        jsonObject("accentTextColor")("darkColor") = accentTextColorDark

        ' Add sub-nests for foregroundColor
        Dim foregroundColorLight As New JObject()
        Dim foregroundColorDark As New JObject()
        If Not colorButton5.IsEmpty Then
            foregroundColorLight("red") = colorButton5.R
            foregroundColorLight("green") = colorButton5.G
            foregroundColorLight("blue") = colorButton5.B
            foregroundColorLight("alpha") = nudLightForegroundAlpha.Value
        End If
        If Not colorButton6.IsEmpty Then
            foregroundColorDark("red") = colorButton6.R
            foregroundColorDark("green") = colorButton6.G
            foregroundColorDark("blue") = colorButton6.B
            foregroundColorDark("alpha") = nudDarkForegroundAlpha.Value
        End If
        jsonObject("foregroundColor") = New JObject()
        jsonObject("foregroundColor")("lightColor") = foregroundColorLight
        jsonObject("foregroundColor")("darkColor") = foregroundColorDark

        ' Add sub-nests for backgroundColor
        Dim backgroundColorLight As New JObject()
        Dim backgroundColorDark As New JObject()
        If Not colorButton7.IsEmpty Then
            backgroundColorLight("red") = colorButton7.R
            backgroundColorLight("green") = colorButton7.G
            backgroundColorLight("blue") = colorButton7.B
            backgroundColorLight("alpha") = nudLightBackgroundAlpha.Value
        End If
        If Not colorButton8.IsEmpty Then
            backgroundColorDark("red") = colorButton8.R
            backgroundColorDark("green") = colorButton8.G
            backgroundColorDark("blue") = colorButton8.B
            backgroundColorDark("alpha") = nudDarkBackgroundAlpha.Value
        End If
        jsonObject("backgroundColor") = New JObject()
        jsonObject("backgroundColor")("lightColor") = backgroundColorLight
        jsonObject("backgroundColor")("darkColor") = backgroundColorDark

        ' Add sub-nests for overlayColor
        Dim overlayColorLight As New JObject()
        Dim overlayColorDark As New JObject()
        If Not colorButton9.IsEmpty Then
            overlayColorLight("red") = colorButton9.R
            overlayColorLight("green") = colorButton9.G
            overlayColorLight("blue") = colorButton9.B
            overlayColorLight("alpha") = nudLightOverlayAlpha.Value
        End If
        If Not colorButton10.IsEmpty Then
            overlayColorDark("red") = colorButton10.R
            overlayColorDark("green") = colorButton10.G
            overlayColorDark("blue") = colorButton10.B
            overlayColorDark("alpha") = nudDarkOverlayAlpha.Value
        End If
        jsonObject("overlayColor") = New JObject()
        jsonObject("overlayColor")("lightColor") = overlayColorLight
        jsonObject("overlayColor")("darkColor") = overlayColorDark

        ' Add sub-nests for separatorColor
        Dim separatorColorLight As New JObject()
        Dim separatorColorDark As New JObject()
        If Not colorButton11.IsEmpty Then
            separatorColorLight("red") = colorButton11.R
            separatorColorLight("green") = colorButton11.G
            separatorColorLight("blue") = colorButton11.B
            separatorColorLight("alpha") = nudLightSeparatorAlpha.Value
        End If
        If Not colorButton12.IsEmpty Then
            separatorColorDark("red") = colorButton12.R
            separatorColorDark("green") = colorButton12.G
            separatorColorDark("blue") = colorButton12.B
            separatorColorDark("alpha") = nudDarkSeparatorAlpha.Value
        End If
        jsonObject("separatorColor") = New JObject()
        jsonObject("separatorColor")("lightColor") = separatorColorLight
        jsonObject("separatorColor")("darkColor") = separatorColorDark

        ' Add sub-nests for bodyTextColor
        Dim bodyTextColorLight As New JObject()
        Dim bodyTextColorDark As New JObject()
        If Not colorButton13.IsEmpty Then
            bodyTextColorLight("red") = colorButton13.R
            bodyTextColorLight("green") = colorButton13.G
            bodyTextColorLight("blue") = colorButton13.B
            bodyTextColorLight("alpha") = nudLightBodyTextAlpha.Value
        End If
        If Not colorButton14.IsEmpty Then
            bodyTextColorDark("red") = colorButton14.R
            bodyTextColorDark("green") = colorButton14.G
            bodyTextColorDark("blue") = colorButton14.B
            bodyTextColorDark("alpha") = nudDarkBodyTextAlpha.Value
        End If
        jsonObject("bodyTextColor") = New JObject()
        jsonObject("bodyTextColor")("lightColor") = bodyTextColorLight
        jsonObject("bodyTextColor")("darkColor") = bodyTextColorDark

        ' Add sub-nests for subtitleTextColor
        Dim subtitleTextColorLight As New JObject()
        Dim subtitleTextColorDark As New JObject()
        If Not colorButton15.IsEmpty Then
            subtitleTextColorLight("red") = colorButton15.R
            subtitleTextColorLight("green") = colorButton15.G
            subtitleTextColorLight("blue") = colorButton15.B
            subtitleTextColorLight("alpha") = nudLightSubtitleTextAlpha.Value
        End If
        If Not colorButton16.IsEmpty Then
            subtitleTextColorDark("red") = colorButton16.R
            subtitleTextColorDark("green") = colorButton16.G
            subtitleTextColorDark("blue") = colorButton16.B
            subtitleTextColorDark("alpha") = nudDarkSubtitleTextAlpha.Value
        End If
        jsonObject("subtitleTextColor") = New JObject()
        jsonObject("subtitleTextColor")("lightColor") = subtitleTextColorLight
        jsonObject("subtitleTextColor")("darkColor") = subtitleTextColorDark

        ' Add sub-nests for buttonNormalBackgroundColor
        Dim buttonNormalBackgroundColorLight As New JObject()
        Dim buttonNormalBackgroundColorDark As New JObject()
        If Not colorButton17.IsEmpty Then
            buttonNormalBackgroundColorLight("red") = colorButton17.R
            buttonNormalBackgroundColorLight("green") = colorButton17.G
            buttonNormalBackgroundColorLight("blue") = colorButton17.B
            buttonNormalBackgroundColorLight("alpha") = nudLightButtonBackgroundAlpha.Value
        End If
        If Not colorButton18.IsEmpty Then
            buttonNormalBackgroundColorDark("red") = colorButton18.R
            buttonNormalBackgroundColorDark("green") = colorButton18.G
            buttonNormalBackgroundColorDark("blue") = colorButton18.B
            buttonNormalBackgroundColorDark("alpha") = nudDarkButtonBackgroundAlpha.Value
        End If
        jsonObject("buttonNormalBackgroundColor") = New JObject()
        jsonObject("buttonNormalBackgroundColor")("lightColor") = buttonNormalBackgroundColorLight
        jsonObject("buttonNormalBackgroundColor")("darkColor") = buttonNormalBackgroundColorDark

        ' Add sub-nests for buttonNormalTextColor
        Dim buttonNormalTextColorLight As New JObject()
        Dim buttonNormalTextColorDark As New JObject()
        If Not colorButton19.IsEmpty Then
            buttonNormalTextColorLight("red") = colorButton19.R
            buttonNormalTextColorLight("green") = colorButton19.G
            buttonNormalTextColorLight("blue") = colorButton19.B
            buttonNormalTextColorLight("alpha") = nudLightButtonTextAlpha.Value
        End If
        If Not colorButton20.IsEmpty Then
            buttonNormalTextColorDark("red") = colorButton20.R
            buttonNormalTextColorDark("green") = colorButton20.G
            buttonNormalTextColorDark("blue") = colorButton20.B
            buttonNormalTextColorDark("alpha") = nudDarkButtonTextAlpha.Value
        End If
        jsonObject("buttonNormalTextColor") = New JObject()
        jsonObject("buttonNormalTextColor")("lightColor") = buttonNormalTextColorLight
        jsonObject("buttonNormalTextColor")("darkColor") = buttonNormalTextColorDark

        ' End of theming options

        Return jsonObject

    End Function

    Private Function GetSRGBJsonObject() As JObject

        ' Create the sRGB JSON object
        Dim sRGBJsonObject As New JObject()
        sRGBJsonObject("creator") = txtThemeCreator.Text

        ' Add sub-nests for accentColor
        Dim accentColorLight As New JObject()
        Dim accentColorDark As New JObject()
        If Not colorButton1.IsEmpty Then
            accentColorLight("red") = colorButton1.R / 255.0
            accentColorLight("green") = colorButton1.G / 255.0
            accentColorLight("blue") = colorButton1.B / 255.0
            accentColorLight("alpha") = nudLightAccentAlpha.Value
        End If
        If Not colorButton2.IsEmpty Then
            accentColorDark("red") = colorButton2.R / 255.0
            accentColorDark("green") = colorButton2.G / 255.0
            accentColorDark("blue") = colorButton2.B / 255.0
            accentColorDark("alpha") = nudDarkAccentAlpha.Value
        End If
        sRGBJsonObject("accentColor") = New JObject()
        sRGBJsonObject("accentColor")("lightColor") = accentColorLight
        sRGBJsonObject("accentColor")("darkColor") = accentColorDark

        ' Add sub-nests for accentTextColor
        Dim accentTextColorLight As New JObject()
        Dim accentTextColorDark As New JObject()
        If Not colorButton3.IsEmpty Then
            accentTextColorLight("red") = colorButton3.R / 255.0
            accentTextColorLight("green") = colorButton3.G / 255.0
            accentTextColorLight("blue") = colorButton3.B / 255.0
            accentTextColorLight("alpha") = nudLightAccentTextAlpha.Value
        End If
        If Not colorButton4.IsEmpty Then
            accentTextColorDark("red") = colorButton4.R / 255.0
            accentTextColorDark("green") = colorButton4.G / 255.0
            accentTextColorDark("blue") = colorButton4.B / 255.0
            accentTextColorDark("alpha") = nudDarkAccentTextAlpha.Value
        End If
        sRGBJsonObject("accentTextColor") = New JObject()
        sRGBJsonObject("accentTextColor")("lightColor") = accentTextColorLight
        sRGBJsonObject("accentTextColor")("darkColor") = accentTextColorDark

        ' Add sub-nests for foregroundColor
        Dim foregroundColorLight As New JObject()
        Dim foregroundColorDark As New JObject()
        If Not colorButton5.IsEmpty Then
            foregroundColorLight("red") = colorButton5.R / 255.0
            foregroundColorLight("green") = colorButton5.G / 255.0
            foregroundColorLight("blue") = colorButton5.B / 255.0
            foregroundColorLight("alpha") = nudLightForegroundAlpha.Value
        End If
        If Not colorButton6.IsEmpty Then
            foregroundColorDark("red") = colorButton6.R / 255.0
            foregroundColorDark("green") = colorButton6.G / 255.0
            foregroundColorDark("blue") = colorButton6.B / 255.0
            foregroundColorDark("alpha") = nudDarkForegroundAlpha.Value
        End If
        sRGBJsonObject("foregroundColor") = New JObject()
        sRGBJsonObject("foregroundColor")("lightColor") = foregroundColorLight
        sRGBJsonObject("foregroundColor")("darkColor") = foregroundColorDark

        ' Add sub-nests for backgroundColor
        Dim backgroundColorLight As New JObject()
        Dim backgroundColorDark As New JObject()
        If Not colorButton7.IsEmpty Then
            backgroundColorLight("red") = colorButton7.R / 255.0
            backgroundColorLight("green") = colorButton7.G / 255.0
            backgroundColorLight("blue") = colorButton7.B / 255.0
            backgroundColorLight("alpha") = nudLightBackgroundAlpha.Value
        End If
        If Not colorButton8.IsEmpty Then
            backgroundColorDark("red") = colorButton8.R / 255.0
            backgroundColorDark("green") = colorButton8.G / 255.0
            backgroundColorDark("blue") = colorButton8.B / 255.0
            backgroundColorDark("alpha") = nudDarkBackgroundAlpha.Value
        End If
        sRGBJsonObject("backgroundColor") = New JObject()
        sRGBJsonObject("backgroundColor")("lightColor") = backgroundColorLight
        sRGBJsonObject("backgroundColor")("darkColor") = backgroundColorDark

        ' Add sub-nests for overlayColor
        Dim overlayColorLight As New JObject()
        Dim overlayColorDark As New JObject()
        If Not colorButton9.IsEmpty Then
            overlayColorLight("red") = colorButton9.R / 255.0
            overlayColorLight("green") = colorButton9.G / 255.0
            overlayColorLight("blue") = colorButton9.B / 255.0
            overlayColorLight("alpha") = nudLightOverlayAlpha.Value
        End If
        If Not colorButton10.IsEmpty Then
            overlayColorDark("red") = colorButton10.R / 255.0
            overlayColorDark("green") = colorButton10.G / 255.0
            overlayColorDark("blue") = colorButton10.B / 255.0
            overlayColorDark("alpha") = nudDarkOverlayAlpha.Value
        End If
        sRGBJsonObject("overlayColor") = New JObject()
        sRGBJsonObject("overlayColor")("lightColor") = overlayColorLight
        sRGBJsonObject("overlayColor")("darkColor") = overlayColorDark

        ' Add sub-nests for separatorColor
        Dim separatorColorLight As New JObject()
        Dim separatorColorDark As New JObject()
        If Not colorButton11.IsEmpty Then
            separatorColorLight("red") = colorButton11.R / 255.0
            separatorColorLight("green") = colorButton11.G / 255.0
            separatorColorLight("blue") = colorButton11.B / 255.0
            separatorColorLight("alpha") = nudLightSeparatorAlpha.Value
        End If
        If Not colorButton12.IsEmpty Then
            separatorColorDark("red") = colorButton12.R / 255.0
            separatorColorDark("green") = colorButton12.G / 255.0
            separatorColorDark("blue") = colorButton12.B / 255.0
            separatorColorDark("alpha") = nudDarkSeparatorAlpha.Value
        End If
        sRGBJsonObject("separatorColor") = New JObject()
        sRGBJsonObject("separatorColor")("lightColor") = separatorColorLight
        sRGBJsonObject("separatorColor")("darkColor") = separatorColorDark

        ' Add sub-nests for bodyTextColor
        Dim bodyTextColorLight As New JObject()
        Dim bodyTextColorDark As New JObject()
        If Not colorButton13.IsEmpty Then
            bodyTextColorLight("red") = colorButton13.R / 255.0
            bodyTextColorLight("green") = colorButton13.G / 255.0
            bodyTextColorLight("blue") = colorButton13.B / 255.0
            bodyTextColorLight("alpha") = nudLightBodyTextAlpha.Value
        End If
        If Not colorButton14.IsEmpty Then
            bodyTextColorDark("red") = colorButton14.R / 255.0
            bodyTextColorDark("green") = colorButton14.G / 255.0
            bodyTextColorDark("blue") = colorButton14.B / 255.0
            bodyTextColorDark("alpha") = nudDarkBodyTextAlpha.Value
        End If
        sRGBJsonObject("bodyTextColor") = New JObject()
        sRGBJsonObject("bodyTextColor")("lightColor") = bodyTextColorLight
        sRGBJsonObject("bodyTextColor")("darkColor") = bodyTextColorDark

        ' Add sub-nests for subtitleTextColor
        Dim subtitleTextColorLight As New JObject()
        Dim subtitleTextColorDark As New JObject()
        If Not colorButton15.IsEmpty Then
            subtitleTextColorLight("red") = colorButton15.R / 255.0
            subtitleTextColorLight("green") = colorButton15.G / 255.0
            subtitleTextColorLight("blue") = colorButton15.B / 255.0
            subtitleTextColorLight("alpha") = nudLightSubtitleTextAlpha.Value
        End If
        If Not colorButton16.IsEmpty Then
            subtitleTextColorDark("red") = colorButton16.R / 255.0
            subtitleTextColorDark("green") = colorButton16.G / 255.0
            subtitleTextColorDark("blue") = colorButton16.B / 255.0
            subtitleTextColorDark("alpha") = nudDarkSubtitleTextAlpha.Value
        End If
        sRGBJsonObject("subtitleTextColor") = New JObject()
        sRGBJsonObject("subtitleTextColor")("lightColor") = subtitleTextColorLight
        sRGBJsonObject("subtitleTextColor")("darkColor") = subtitleTextColorDark

        ' Add sub-nests for buttonNormalBackgroundColor
        Dim buttonNormalBackgroundColorLight As New JObject()
        Dim buttonNormalBackgroundColorDark As New JObject()
        If Not colorButton17.IsEmpty Then
            buttonNormalBackgroundColorLight("red") = colorButton17.R / 255.0
            buttonNormalBackgroundColorLight("green") = colorButton17.G / 255.0
            buttonNormalBackgroundColorLight("blue") = colorButton17.B / 255.0
            buttonNormalBackgroundColorLight("alpha") = nudLightButtonBackgroundAlpha.Value
        End If
        If Not colorButton18.IsEmpty Then
            buttonNormalBackgroundColorDark("red") = colorButton18.R / 255.0
            buttonNormalBackgroundColorDark("green") = colorButton18.G / 255.0
            buttonNormalBackgroundColorDark("blue") = colorButton18.B / 255.0
            buttonNormalBackgroundColorDark("alpha") = nudDarkButtonBackgroundAlpha.Value
        End If
        sRGBJsonObject("buttonNormalBackgroundColor") = New JObject()
        sRGBJsonObject("buttonNormalBackgroundColor")("lightColor") = buttonNormalBackgroundColorLight
        sRGBJsonObject("buttonNormalBackgroundColor")("darkColor") = buttonNormalBackgroundColorDark

        ' Add sub-nests for buttonNormalTextColor
        Dim buttonNormalTextColorLight As New JObject()
        Dim buttonNormalTextColorDark As New JObject()
        If Not colorButton19.IsEmpty Then
            buttonNormalTextColorLight("red") = colorButton19.R / 255.0
            buttonNormalTextColorLight("green") = colorButton19.G / 255.0
            buttonNormalTextColorLight("blue") = colorButton19.B / 255.0
            buttonNormalTextColorLight("alpha") = nudLightButtonTextAlpha.Value
        End If
        If Not colorButton20.IsEmpty Then
            buttonNormalTextColorDark("red") = colorButton20.R / 255.0
            buttonNormalTextColorDark("green") = colorButton20.G / 255.0
            buttonNormalTextColorDark("blue") = colorButton20.B / 255.0
            buttonNormalTextColorDark("alpha") = nudDarkButtonTextAlpha.Value
        End If
        sRGBJsonObject("buttonNormalTextColor") = New JObject()
        sRGBJsonObject("buttonNormalTextColor")("lightColor") = buttonNormalTextColorLight
        sRGBJsonObject("buttonNormalTextColor")("darkColor") = buttonNormalTextColorDark

        ' End of theming options

        Return sRGBJsonObject

    End Function
    Private Function GetHexJsonObject() As JObject

        ' Create a new JObject for Hex codes
        Dim hexJsonObject As New JObject()
        hexJsonObject("creator") = txtThemeCreator.Text

        ' Add sub-nests for accentColor
        Dim accentColorLight As New JObject()
        Dim accentColorDark As New JObject()
        If Not colorButton1.IsEmpty Then
            accentColorLight("hexCode") = ColorToHex(colorButton1)
            accentColorLight("alpha") = nudLightAccentAlpha.Value
        End If
        If Not colorButton2.IsEmpty Then
            accentColorDark("hexCode") = ColorToHex(colorButton2)
            accentColorDark("alpha") = nudDarkAccentAlpha.Value
        End If
        hexJsonObject("accentColor") = New JObject()
        hexJsonObject("accentColor")("lightColor") = accentColorLight
        hexJsonObject("accentColor")("darkColor") = accentColorDark

        ' Add sub-nests for accentTextColor
        Dim accentTextColorLight As New JObject()
        Dim accentTextColorDark As New JObject()
        If Not colorButton3.IsEmpty Then
            accentTextColorLight("hexCode") = ColorToHex(colorButton3)
            accentTextColorLight("alpha") = nudLightAccentTextAlpha.Value
        End If
        If Not colorButton4.IsEmpty Then
            accentTextColorDark("hexCode") = ColorToHex(colorButton4)
            accentTextColorDark("alpha") = nudDarkAccentTextAlpha.Value
        End If
        hexJsonObject("accentTextColor") = New JObject()
        hexJsonObject("accentTextColor")("lightColor") = accentTextColorLight
        hexJsonObject("accentTextColor")("darkColor") = accentTextColorDark

        ' Add sub-nests for foregroundColor
        Dim foregroundColorLight As New JObject()
        Dim foregroundColorDark As New JObject()
        If Not colorButton5.IsEmpty Then
            foregroundColorLight("hexCode") = ColorToHex(colorButton5)
            foregroundColorLight("alpha") = nudLightForegroundAlpha.Value
        End If
        If Not colorButton6.IsEmpty Then
            foregroundColorDark("hexCode") = ColorToHex(colorButton6)
            foregroundColorDark("alpha") = nudDarkForegroundAlpha.Value
        End If
        hexJsonObject("foregroundColor") = New JObject()
        hexJsonObject("foregroundColor")("lightColor") = foregroundColorLight
        hexJsonObject("foregroundColor")("darkColor") = foregroundColorDark

        ' Add sub-nests for backgroundColor
        Dim backgroundColorLight As New JObject()
        Dim backgroundColorDark As New JObject()
        If Not colorButton7.IsEmpty Then
            backgroundColorLight("hexCode") = ColorToHex(colorButton7)
            backgroundColorLight("alpha") = nudLightBackgroundAlpha.Value
        End If
        If Not colorButton8.IsEmpty Then
            backgroundColorDark("hexCode") = ColorToHex(colorButton8)
            backgroundColorDark("alpha") = nudDarkBackgroundAlpha.Value
        End If
        hexJsonObject("backgroundColor") = New JObject()
        hexJsonObject("backgroundColor")("lightColor") = backgroundColorLight
        hexJsonObject("backgroundColor")("darkColor") = backgroundColorDark

        ' Add sub-nests for overlayColor
        Dim overlayColorLight As New JObject()
        Dim overlayColorDark As New JObject()
        If Not colorButton9.IsEmpty Then
            overlayColorLight("hexCode") = ColorToHex(colorButton9)
            overlayColorLight("alpha") = nudLightOverlayAlpha.Value
        End If
        If Not colorButton10.IsEmpty Then
            overlayColorDark("hexCode") = ColorToHex(colorButton10)
            overlayColorDark("alpha") = nudDarkOverlayAlpha.Value
        End If
        hexJsonObject("overlayColor") = New JObject()
        hexJsonObject("overlayColor")("lightColor") = overlayColorLight
        hexJsonObject("overlayColor")("darkColor") = overlayColorDark

        ' Add sub-nests for separatorColor
        Dim separatorColorLight As New JObject()
        Dim separatorColorDark As New JObject()
        If Not colorButton11.IsEmpty Then
            separatorColorLight("hexCode") = ColorToHex(colorButton11)
            separatorColorLight("alpha") = nudLightSeparatorAlpha.Value
        End If
        If Not colorButton12.IsEmpty Then
            separatorColorDark("hexCode") = ColorToHex(colorButton12)
            separatorColorDark("alpha") = nudDarkSeparatorAlpha.Value
        End If
        hexJsonObject("separatorColor") = New JObject()
        hexJsonObject("separatorColor")("lightColor") = separatorColorLight
        hexJsonObject("separatorColor")("darkColor") = separatorColorDark

        ' Add sub-nests for bodyTextColor
        Dim bodyTextColorLight As New JObject()
        Dim bodyTextColorDark As New JObject()
        If Not colorButton13.IsEmpty Then
            bodyTextColorLight("hexCode") = ColorToHex(colorButton13)
            bodyTextColorLight("alpha") = nudLightBodyTextAlpha.Value
        End If
        If Not colorButton14.IsEmpty Then
            bodyTextColorDark("hexCode") = ColorToHex(colorButton14)
            bodyTextColorDark("alpha") = nudDarkBodyTextAlpha.Value
        End If
        hexJsonObject("bodyTextColor") = New JObject()
        hexJsonObject("bodyTextColor")("lightColor") = bodyTextColorLight
        hexJsonObject("bodyTextColor")("darkColor") = bodyTextColorDark

        ' Add sub-nests for subtitleTextColor
        Dim subtitleTextColorLight As New JObject()
        Dim subtitleTextColorDark As New JObject()
        If Not colorButton15.IsEmpty Then
            subtitleTextColorLight("hexCode") = ColorToHex(colorButton15)
            subtitleTextColorLight("alpha") = nudLightSubtitleTextAlpha.Value
        End If
        If Not colorButton16.IsEmpty Then
            subtitleTextColorDark("hexCode") = ColorToHex(colorButton16)
            subtitleTextColorDark("alpha") = nudDarkSubtitleTextAlpha.Value
        End If
        hexJsonObject("subtitleTextColor") = New JObject()
        hexJsonObject("subtitleTextColor")("lightColor") = subtitleTextColorLight
        hexJsonObject("subtitleTextColor")("darkColor") = subtitleTextColorDark

        ' Add sub-nests for buttonNormalBackgroundColor
        Dim buttonNormalBackgroundColorLight As New JObject()
        Dim buttonNormalBackgroundColorDark As New JObject()
        If Not colorButton17.IsEmpty Then
            buttonNormalBackgroundColorLight("hexCode") = ColorToHex(colorButton17)
            buttonNormalBackgroundColorLight("alpha") = nudLightButtonBackgroundAlpha.Value
        End If
        If Not colorButton18.IsEmpty Then
            buttonNormalBackgroundColorDark("hexCode") = ColorToHex(colorButton18)
            buttonNormalBackgroundColorDark("alpha") = nudDarkButtonBackgroundAlpha.Value
        End If
        hexJsonObject("buttonNormalBackgroundColor") = New JObject()
        hexJsonObject("buttonNormalBackgroundColor")("lightColor") = buttonNormalBackgroundColorLight
        hexJsonObject("buttonNormalBackgroundColor")("darkColor") = buttonNormalBackgroundColorDark

        ' Add sub-nests for buttonNormalTextColor
        Dim buttonNormalTextColorLight As New JObject()
        Dim buttonNormalTextColorDark As New JObject()
        If Not colorButton19.IsEmpty Then
            buttonNormalTextColorLight("hexCode") = ColorToHex(colorButton19)
            buttonNormalTextColorLight("alpha") = nudLightButtonTextAlpha.Value
        End If
        If Not colorButton20.IsEmpty Then
            buttonNormalTextColorDark("hexCode") = ColorToHex(colorButton20)
            buttonNormalTextColorDark("alpha") = nudDarkButtonTextAlpha.Value
        End If
        hexJsonObject("buttonNormalTextColor") = New JObject()
        hexJsonObject("buttonNormalTextColor")("lightColor") = buttonNormalTextColorLight
        hexJsonObject("buttonNormalTextColor")("darkColor") = buttonNormalTextColorDark

        ' End of theming options

        Return hexJsonObject

    End Function

    Private Sub WriteJSON(filePath As String, data As JObject)
        ' Convert the JObject to a JSON string
        Dim jsonContent As String = data.ToString()

        ' Write the JSON content to a new file, overwriting if it already exists
        File.WriteAllText(filePath, jsonContent)
    End Sub

    Private Function ColorToHex(color As Color) As String

        ' Fix colors returning as names instead of hex
        Return $"#{color.R.ToString("X2")}{color.G.ToString("X2")}{color.B.ToString("X2")}"

    End Function

    Private Sub SaveColorData()

        ' Define the save directory path
        Dim directoryPath As String = "./paperback_themes/"

        ' Check if the directory exists
        If Not Directory.Exists(directoryPath) Then
            ' Create the directory if it doesn't exist
            Directory.CreateDirectory(directoryPath)
        End If

        ' Write JSON data to files
        WriteJSON(Path.Combine(directoryPath, $"{txtThemeName.Text}.pbcolors"), GetSRGBJsonObject())

        If chkRGBA.Checked = True Then

            WriteJSON(Path.Combine(directoryPath, $"{txtThemeName.Text}_RGBA.pbcolors"), GetRGBJsonObject())

        End If

        If chkHEXA.Checked = True Then

            WriteJSON(Path.Combine(directoryPath, $"{txtThemeName.Text}_HEXA.pbcolors"), GetHexJsonObject())

        End If

        MessageBox.Show("Theme has been saved to ./paperback_themes!", "Success")

    End Sub

    Private Sub btnWriteJson_Click(sender As Object, e As EventArgs) Handles btnWriteJson.Click

        ' Check if the Theme Creator text box contains default text or is empty
        If txtThemeCreator.Text = "Theme Creator" OrElse String.IsNullOrEmpty(txtThemeCreator.Text.Trim()) Then
            ' Set default value for Theme Creator if necessary
            txtThemeCreator.Text = "PBT_GUI"
        End If

        ' Check if the Theme Name text box contains default text or is empty
        If txtThemeName.Text = "Theme Name" OrElse String.IsNullOrEmpty(txtThemeName.Text.Trim()) Then
            ' Set default value for Theme Name if necessary
            txtThemeName.Text = "AwesomePaperbackTheme"
        End If

        ' Save the color data
        SaveColorData()

    End Sub

    Private Sub btnLightAccent_Click(sender As Object, e As EventArgs) Handles btnLightAccent.Click

        colorButton1 = ColorTranslator.FromHtml("#FD6A68")
        pbxlightAccent.BackColor = colorButton1
        nudLightAccentAlpha.Value = 1

    End Sub

    Private Sub btnDarkAccent_Click(sender As Object, e As EventArgs) Handles btnDarkAccent.Click

        colorButton2 = ColorTranslator.FromHtml("#FD6A68")
        pbxDarkAccent.BackColor = colorButton2
        nudDarkAccentAlpha.Value = 1

    End Sub

    Private Sub btnLightAccentText_Click(sender As Object, e As EventArgs) Handles btnLightAccentText.Click

        colorButton3 = ColorTranslator.FromHtml("#FFFFFF")
        pbxLightAccentText.BackColor = colorButton3
        nudLightAccentTextAlpha.Value = 1

    End Sub

    Private Sub btnDarkAccentText_Click(sender As Object, e As EventArgs) Handles btnDarkAccentText.Click

        colorButton4 = ColorTranslator.FromHtml("#EBEBEB")
        pbxDarkAccentText.BackColor = colorButton4
        nudDarkAccentTextAlpha.Value = 1

    End Sub

    Private Sub btnLightForeground_Click(sender As Object, e As EventArgs) Handles btnLightForeground.Click

        colorButton5 = ColorTranslator.FromHtml("#FCFFFF")
        pbxLightForeground.BackColor = colorButton5
        nudLightForegroundAlpha.Value = 1

    End Sub

    Private Sub btnDarkForeground_Click(sender As Object, e As EventArgs) Handles btnDarkForeground.Click

        colorButton6 = ColorTranslator.FromHtml("#171717")
        pbxDarkForeground.BackColor = colorButton6
        nudDarkForegroundAlpha.Value = 1

    End Sub

    Private Sub btnLightBackground_Click(sender As Object, e As EventArgs) Handles btnLightBackground.Click

        colorButton7 = ColorTranslator.FromHtml("#F2F2F2")
        pbxLightBackground.BackColor = colorButton7
        nudLightBackgroundAlpha.Value = 1

    End Sub

    Private Sub btnDarkBackground_Click(sender As Object, e As EventArgs) Handles btnDarkBackground.Click

        colorButton8 = ColorTranslator.FromHtml("#000000")
        pbxDarkBackground.BackColor = colorButton8
        nudDarkBackgroundAlpha.Value = 1

    End Sub

    Private Sub btnLightOverlay_Click(sender As Object, e As EventArgs) Handles btnLightOverlay.Click

        colorButton9 = ColorTranslator.FromHtml("#F2F2F2")
        pbxLightOverlay.BackColor = colorButton9
        nudLightOverlayAlpha.Value = 0.3
        ' Need to update the nudAlpha again to fix a bug where default value jumps to 1 after the first click
        nudLightOverlayAlpha_ValueChanged(nudLightOverlayAlpha, EventArgs.Empty)

    End Sub

    Private Sub btnDarkOverlay_Click(sender As Object, e As EventArgs) Handles btnDarkOverlay.Click

        colorButton10 = ColorTranslator.FromHtml("#000000")
        pbxDarkOverlay.BackColor = colorButton10
        nudDarkOverlayAlpha.Value = 0.3
        nudDarkOverlayAlpha_ValueChanged(nudDarkOverlayAlpha, EventArgs.Empty)

    End Sub

    Private Sub btnLightSeparator_Click(sender As Object, e As EventArgs) Handles btnLightSeparator.Click

        colorButton11 = ColorTranslator.FromHtml("#3C3C43")
        pbxLightSeparator.BackColor = colorButton11
        nudLightSeparatorAlpha.Value = 0.3
        nudLightSeparatorAlpha_ValueChanged(nudLightSeparatorAlpha, EventArgs.Empty)

    End Sub

    Private Sub btnDarkSeparator_Click(sender As Object, e As EventArgs) Handles btnDarkSeparator.Click

        colorButton12 = ColorTranslator.FromHtml("#545458")
        pbxDarkSeparator.BackColor = colorButton12
        nudDarkSeparatorAlpha.Value = 0.3
        nudDarkSeparatorAlpha_ValueChanged(nudDarkSeparatorAlpha, EventArgs.Empty)

    End Sub

    Private Sub btnLightBodyText_Click(sender As Object, e As EventArgs) Handles btnLightBodyText.Click

        colorButton13 = ColorTranslator.FromHtml("#212121")
        pbxLightBodyText.BackColor = colorButton13
        nudLightBodyTextAlpha.Value = 1

    End Sub

    Private Sub btnDarkBodyText_Click(sender As Object, e As EventArgs) Handles btnDarkBodyText.Click

        colorButton14 = ColorTranslator.FromHtml("#EBEBEB")
        pbxDarkBodyText.BackColor = colorButton14
        nudDarkBodyTextAlpha.Value = 1

    End Sub

    Private Sub btnLightSubtitleText_Click(sender As Object, e As EventArgs) Handles btnLightSubtitleText.Click

        colorButton15 = ColorTranslator.FromHtml("#5F5F5F")
        pbxLightSubtitleText.BackColor = colorButton15
        nudLightSubtitleTextAlpha.Value = 1

    End Sub

    Private Sub btnDarkSubtitleText_Click(sender As Object, e As EventArgs) Handles btnDarkSubtitleText.Click

        colorButton16 = ColorTranslator.FromHtml("#C0C0C0")
        pbxDarkSubtitleText.BackColor = colorButton16
        nudDarkSubtitleTextAlpha.Value = 1

    End Sub

    Private Sub btnLightButtonBackground_Click(sender As Object, e As EventArgs) Handles btnLightButtonBackground.Click

        colorButton17 = ColorTranslator.FromHtml("#FD6A68")
        pbxLightButtonBackground.BackColor = colorButton17
        nudLightButtonBackgroundAlpha.Value = 0.3
        nudLightButtonBackgroundAlpha_ValueChanged(nudLightButtonBackgroundAlpha, EventArgs.Empty)

    End Sub

    Private Sub btnDarkButtonBackground_Click(sender As Object, e As EventArgs) Handles btnDarkButtonBackground.Click

        colorButton18 = ColorTranslator.FromHtml("#FD6A68")
        pbxDarkButtonBackground.BackColor = colorButton18
        nudDarkButtonBackgroundAlpha.Value = 0.3
        nudDarkButtonBackgroundAlpha_ValueChanged(nudDarkButtonBackgroundAlpha, EventArgs.Empty)

    End Sub

    Private Sub btnLightButtonText_Click(sender As Object, e As EventArgs) Handles btnLightButtonText.Click

        colorButton19 = ColorTranslator.FromHtml("#212121")
        pbxLightButtonText.BackColor = colorButton19
        nudLightButtonTextAlpha.Value = 1

    End Sub

    Private Sub btnDarkButtonText_Click(sender As Object, e As EventArgs) Handles btnDarkButtonText.Click

        colorButton20 = ColorTranslator.FromHtml("#EBEBEB")
        pbxDarkButtonText.BackColor = colorButton20
        nudDarkButtonTextAlpha.Value = 1

    End Sub

    Private Sub btnOpenJson_Click(sender As Object, e As EventArgs) Handles btnOpenJson.Click

        ' Show the open file dialog
        Dim openFileDialog As New OpenFileDialog()
        Dim fileNameString As String
        openFileDialog.Filter = "pbcolors Files (*.pbcolors)|*.pbcolors"
        openFileDialog.Title = "Select File"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                ' Assign file name to string
                fileNameString = Path.GetFileNameWithoutExtension(openFileDialog.FileName)
                ' Read the selected JSON file
                Dim jsonText As String = File.ReadAllText(openFileDialog.FileName)

                ' Parse the JSON string into a JObject
                Dim jsonObject As JObject = JObject.Parse(jsonText)

                ' Assign colors to variables based on the JSON data
                colorButton1 = GetColorFromJson(jsonObject("accentColor")("lightColor"))
                colorButton2 = GetColorFromJson(jsonObject("accentColor")("darkColor"))
                colorButton3 = GetColorFromJson(jsonObject("accentTextColor")("lightColor"))
                colorButton4 = GetColorFromJson(jsonObject("accentTextColor")("darkColor"))
                colorButton5 = GetColorFromJson(jsonObject("foregroundColor")("lightColor"))
                colorButton6 = GetColorFromJson(jsonObject("foregroundColor")("darkColor"))
                colorButton7 = GetColorFromJson(jsonObject("backgroundColor")("lightColor"))
                colorButton8 = GetColorFromJson(jsonObject("backgroundColor")("darkColor"))
                colorButton9 = GetColorFromJson(jsonObject("overlayColor")("lightColor"))
                colorButton10 = GetColorFromJson(jsonObject("overlayColor")("darkColor"))
                colorButton11 = GetColorFromJson(jsonObject("separatorColor")("lightColor"))
                colorButton12 = GetColorFromJson(jsonObject("separatorColor")("darkColor"))
                colorButton13 = GetColorFromJson(jsonObject("bodyTextColor")("lightColor"))
                colorButton14 = GetColorFromJson(jsonObject("bodyTextColor")("darkColor"))
                colorButton15 = GetColorFromJson(jsonObject("subtitleTextColor")("lightColor"))
                colorButton16 = GetColorFromJson(jsonObject("subtitleTextColor")("darkColor"))
                colorButton17 = GetColorFromJson(jsonObject("buttonNormalBackgroundColor")("lightColor"))
                colorButton18 = GetColorFromJson(jsonObject("buttonNormalBackgroundColor")("darkColor"))
                colorButton19 = GetColorFromJson(jsonObject("buttonNormalTextColor")("lightColor"))
                colorButton20 = GetColorFromJson(jsonObject("buttonNormalTextColor")("darkColor"))

                ' Set the alpha values
                nudLightAccentAlpha.Value = Convert.ToDouble(jsonObject("accentColor")("lightColor")("alpha"))
                nudDarkAccentAlpha.Value = Convert.ToDouble(jsonObject("accentColor")("darkColor")("alpha"))
                nudLightAccentTextAlpha.Value = Convert.ToDouble(jsonObject("accentTextColor")("lightColor")("alpha"))
                nudDarkAccentTextAlpha.Value = Convert.ToDouble(jsonObject("accentTextColor")("darkColor")("alpha"))
                nudLightForegroundAlpha.Value = Convert.ToDouble(jsonObject("foregroundColor")("lightColor")("alpha"))
                nudDarkForegroundAlpha.Value = Convert.ToDouble(jsonObject("foregroundColor")("darkColor")("alpha"))
                nudLightBackgroundAlpha.Value = Convert.ToDouble(jsonObject("backgroundColor")("lightColor")("alpha"))
                nudDarkBackgroundAlpha.Value = Convert.ToDouble(jsonObject("backgroundColor")("darkColor")("alpha"))
                nudLightOverlayAlpha.Value = Convert.ToDouble(jsonObject("overlayColor")("lightColor")("alpha"))
                nudDarkOverlayAlpha.Value = Convert.ToDouble(jsonObject("overlayColor")("darkColor")("alpha"))
                nudLightSeparatorAlpha.Value = Convert.ToDouble(jsonObject("separatorColor")("lightColor")("alpha"))
                nudDarkSeparatorAlpha.Value = Convert.ToDouble(jsonObject("separatorColor")("darkColor")("alpha"))
                nudLightBodyTextAlpha.Value = Convert.ToDouble(jsonObject("bodyTextColor")("lightColor")("alpha"))
                nudDarkBodyTextAlpha.Value = Convert.ToDouble(jsonObject("bodyTextColor")("darkColor")("alpha"))
                nudLightSubtitleTextAlpha.Value = Convert.ToDouble(jsonObject("subtitleTextColor")("lightColor")("alpha"))
                nudDarkSubtitleTextAlpha.Value = Convert.ToDouble(jsonObject("subtitleTextColor")("darkColor")("alpha"))
                nudLightButtonBackgroundAlpha.Value = Convert.ToDouble(jsonObject("buttonNormalBackgroundColor")("lightColor")("alpha"))
                nudDarkButtonBackgroundAlpha.Value = Convert.ToDouble(jsonObject("buttonNormalBackgroundColor")("darkColor")("alpha"))
                nudLightButtonTextAlpha.Value = Convert.ToDouble(jsonObject("buttonNormalTextColor")("lightColor")("alpha"))
                nudDarkButtonTextAlpha.Value = Convert.ToDouble(jsonObject("buttonNormalTextColor")("darkColor")("alpha"))

                ' Set the colors of buttons based on the assigned color variables
                pbxlightAccent.BackColor = colorButton1
                nudLightAccentAlpha_ValueChanged(nudLightAccentAlpha, EventArgs.Empty)

                pbxDarkAccent.BackColor = colorButton2
                nudDarkAccentAlpha_ValueChanged(nudDarkAccentAlpha, EventArgs.Empty)

                pbxLightAccentText.BackColor = colorButton3
                nudLightAccentTextAlpha_ValueChanged(nudLightAccentTextAlpha, EventArgs.Empty)

                pbxDarkAccentText.BackColor = colorButton4
                nudDarkAccentTextAlpha_ValueChanged(nudDarkAccentTextAlpha, EventArgs.Empty)

                pbxLightForeground.BackColor = colorButton5
                nudLightForegroundAlpha_ValueChanged(nudLightForegroundAlpha, EventArgs.Empty)

                pbxDarkForeground.BackColor = colorButton6
                nudDarkForegroundAlpha_ValueChanged(nudDarkForegroundAlpha, EventArgs.Empty)

                pbxLightBackground.BackColor = colorButton7
                nudLightBackgroundAlpha_ValueChanged(nudLightBackgroundAlpha, EventArgs.Empty)

                pbxDarkBackground.BackColor = colorButton8
                nudDarkBackgroundAlpha_ValueChanged(nudDarkBackgroundAlpha, EventArgs.Empty)

                pbxLightOverlay.BackColor = colorButton9
                nudLightOverlayAlpha_ValueChanged(nudLightOverlayAlpha, EventArgs.Empty)

                pbxDarkOverlay.BackColor = colorButton10
                nudDarkOverlayAlpha_ValueChanged(nudDarkOverlayAlpha, EventArgs.Empty)

                pbxLightSeparator.BackColor = colorButton11
                nudLightSeparatorAlpha_ValueChanged(nudLightSeparatorAlpha, EventArgs.Empty)

                pbxDarkSeparator.BackColor = colorButton12
                nudDarkSeparatorAlpha_ValueChanged(nudDarkSeparatorAlpha, EventArgs.Empty)

                pbxLightBodyText.BackColor = colorButton13
                nudLightBodyTextAlpha_ValueChanged(nudLightBodyTextAlpha, EventArgs.Empty)

                pbxDarkBodyText.BackColor = colorButton14
                nudDarkBodyTextAlpha_ValueChanged(nudDarkBodyTextAlpha, EventArgs.Empty)

                pbxLightSubtitleText.BackColor = colorButton15
                nudLightSubtitleTextAlpha_ValueChanged(nudLightSubtitleTextAlpha, EventArgs.Empty)

                pbxDarkSubtitleText.BackColor = colorButton16
                nudDarkSubtitleTextAlpha_ValueChanged(nudDarkSubtitleTextAlpha, EventArgs.Empty)

                pbxLightButtonBackground.BackColor = colorButton17
                nudLightButtonBackgroundAlpha_ValueChanged(nudLightButtonBackgroundAlpha, EventArgs.Empty)

                pbxDarkButtonBackground.BackColor = colorButton18
                nudDarkButtonBackgroundAlpha_ValueChanged(nudDarkButtonBackgroundAlpha, EventArgs.Empty)

                pbxLightButtonText.BackColor = colorButton19
                nudLightButtonTextAlpha_ValueChanged(nudLightButtonTextAlpha, EventArgs.Empty)

                pbxDarkButtonText.BackColor = colorButton20
                nudDarkButtonTextAlpha_ValueChanged(nudDarkButtonTextAlpha, EventArgs.Empty)


                ' Set the tex box values
                If jsonObject.ContainsKey("creator") AndAlso jsonObject("creator") IsNot Nothing Then

                    txtThemeCreator.Text = jsonObject("creator").ToString()

                Else
                    ' Provide a default value
                    txtThemeCreator.Text = "Theme Creator"
                End If

                txtThemeName.Text = fileNameString

            Catch ex As Exception

                MessageBox.Show("An error occurred while reading the JSON file: " & ex.Message, "Error")

            End Try


        End If

    End Sub

    ' Function to convert color values from JSON to Color objects
    Private Function GetColorFromJson(colorJson As JObject) As Color

        Dim red As Integer
        Dim green As Integer
        Dim blue As Integer
        Dim errorMessage As String = ""
        Dim hasError As Boolean = False

        Try
            ' Check if hexCode is present and convert it to Color object if valid
            If colorJson("hexCode") IsNot Nothing AndAlso Not String.IsNullOrEmpty(colorJson("hexCode").ToString()) Then
                Dim hexCode As String = colorJson("hexCode").ToString().TrimStart("#"c)

                ' Validate hex code length
                If hexCode.Length = 6 OrElse hexCode.Length = 8 Then
                    ' Extract RGB values from hex code
                    red = Convert.ToInt32(hexCode.Substring(0, 2), 16)
                    green = Convert.ToInt32(hexCode.Substring(2, 2), 16)
                    blue = Convert.ToInt32(hexCode.Substring(4, 2), 16)

                    ' Check if hex code includes alpha component
                    If hexCode.Length = 8 Then
                        Dim alpha As Integer = Convert.ToInt32(hexCode.Substring(6, 2), 16)
                        Return Color.FromArgb(alpha, red, green, blue)
                    Else
                        Return Color.FromArgb(red, green, blue)
                    End If
                Else
                    ' Add error message for invalid hex code length
                    errorMessage &= "Invalid hex code length." & vbCrLf
                    hasError = True
                End If
            ElseIf TypeOf colorJson("red") Is JValue AndAlso IsNumeric(colorJson("red")) Then
                ' Convert sRGB value to RGB if necessary for red component
                If Convert.ToDouble(colorJson("red")) <= 1 Then
                    red = CInt(Math.Min(Math.Max(Convert.ToDouble(colorJson("red")) * 255, 0), 255))
                Else
                    red = CInt(Math.Min(Math.Max(Convert.ToDouble(colorJson("red")), 0), 255))
                End If
            Else
                ' Add error message for invalid or missing color values
                errorMessage &= "Invalid or missing red color value." & vbCrLf
                hasError = True
            End If

            ' Convert sRGB value to RGB if necessary for green component
            If TypeOf colorJson("green") Is JValue AndAlso IsNumeric(colorJson("green")) Then
                If Convert.ToDouble(colorJson("green")) <= 1 Then
                    green = CInt(Math.Min(Math.Max(Convert.ToDouble(colorJson("green")) * 255, 0), 255))
                Else
                    green = CInt(Math.Min(Math.Max(Convert.ToDouble(colorJson("green")), 0), 255))
                End If
            Else
                ' Add error message for invalid or missing green color value
                errorMessage &= "Invalid or missing green color value." & vbCrLf
                hasError = True
            End If

            ' Convert sRGB value to RGB if necessary for blue component
            If TypeOf colorJson("blue") Is JValue AndAlso IsNumeric(colorJson("blue")) Then
                If Convert.ToDouble(colorJson("blue")) <= 1 Then
                    blue = CInt(Math.Min(Math.Max(Convert.ToDouble(colorJson("blue")) * 255, 0), 255))
                Else
                    blue = CInt(Math.Min(Math.Max(Convert.ToDouble(colorJson("blue")), 0), 255))
                End If
            Else
                ' Add error message for invalid or missing blue color value
                errorMessage &= "Invalid or missing blue color value." & vbCrLf
                hasError = True
            End If

            Return Color.FromArgb(red, green, blue)

        Catch ex As Exception
            ' Show error message for any exceptions
            If hasError Then
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            ' Default color if error occurs
            Return Color.Black

        End Try

    End Function

    Private Sub txtThemeCreator_GotFocus(sender As Object, e As EventArgs) Handles txtThemeCreator.GotFocus

        ' Check if the text box contains the default text "Theme Creator"
        If txtThemeCreator.Text = "Theme Creator" Then

            txtThemeCreator.Text = ""

        End If

    End Sub

    Private Sub txtThemeName_GotFocus(sender As Object, e As EventArgs) Handles txtThemeName.GotFocus

        ' Check if the text box contains the default text "Theme Name"
        If txtThemeName.Text = "Theme Name" Then

            txtThemeName.Text = ""

        End If
    End Sub

    Private Sub pbxlightAccent_Click(sender As Object, e As EventArgs) Handles pbxlightAccent.Click

        OpenColorPicker(1)

    End Sub

    Private Sub nudLightAccentAlpha_ValueChanged(sender As Object, e As EventArgs) Handles nudLightAccentAlpha.ValueChanged

        ' Get the alpha value from the numeric up-down control
        Dim alpha As Double = CDbl(nudLightAccentAlpha.Value)

        ' Ensure the alpha value is within the valid range
        alpha = Math.Min(Math.Max(alpha, 0), 1)

        ' Get the existing back color of the PictureBox
        Dim existingColor As Color = pbxlightAccent.BackColor

        ' Create a new color with the adjusted alpha value
        Dim adjustedColor As Color = Color.FromArgb(CInt(alpha * 255), existingColor)

        ' Set the back color of the PictureBox to the new color with adjusted alpha
        pbxlightAccent.BackColor = adjustedColor

    End Sub

    Private Sub pbxDarkAccent_Click(sender As Object, e As EventArgs) Handles pbxDarkAccent.Click

        OpenColorPicker(2)

    End Sub

    Private Sub nudDarkAccentAlpha_ValueChanged(sender As Object, e As EventArgs) Handles nudDarkAccentAlpha.ValueChanged

        Dim alpha As Double = CDbl(nudDarkAccentAlpha.Value)

        alpha = Math.Min(Math.Max(alpha, 0), 1)

        Dim existingColor As Color = pbxDarkAccent.BackColor

        Dim adjustedColor As Color = Color.FromArgb(CInt(alpha * 255), existingColor)

        pbxDarkAccent.BackColor = adjustedColor

    End Sub

    Private Sub pbxLightAccentText_Click(sender As Object, e As EventArgs) Handles pbxLightAccentText.Click

        OpenColorPicker(3)

    End Sub

    Private Sub nudLightAccentTextAlpha_ValueChanged(sender As Object, e As EventArgs) Handles nudLightAccentTextAlpha.ValueChanged

        Dim alpha As Double = CDbl(nudLightAccentTextAlpha.Value)

        alpha = Math.Min(Math.Max(alpha, 0), 1)

        Dim existingColor As Color = pbxLightAccentText.BackColor

        Dim adjustedColor As Color = Color.FromArgb(CInt(alpha * 255), existingColor)

        pbxLightAccentText.BackColor = adjustedColor

    End Sub

    Private Sub pbxDarkAccentText_Click(sender As Object, e As EventArgs) Handles pbxDarkAccentText.Click

        OpenColorPicker(4)

    End Sub

    Private Sub nudDarkAccentTextAlpha_ValueChanged(sender As Object, e As EventArgs) Handles nudDarkAccentTextAlpha.ValueChanged

        Dim alpha As Double = CDbl(nudDarkAccentTextAlpha.Value)

        alpha = Math.Min(Math.Max(alpha, 0), 1)

        Dim existingColor As Color = pbxDarkAccentText.BackColor

        Dim adjustedColor As Color = Color.FromArgb(CInt(alpha * 255), existingColor)

        pbxDarkAccentText.BackColor = adjustedColor

    End Sub

    Private Sub pbxLightForeground_Click(sender As Object, e As EventArgs) Handles pbxLightForeground.Click

        OpenColorPicker(5)

    End Sub

    Private Sub nudLightForegroundAlpha_ValueChanged(sender As Object, e As EventArgs) Handles nudLightForegroundAlpha.ValueChanged

        Dim alpha As Double = CDbl(nudLightForegroundAlpha.Value)

        alpha = Math.Min(Math.Max(alpha, 0), 1)

        Dim existingColor As Color = pbxLightForeground.BackColor

        Dim adjustedColor As Color = Color.FromArgb(CInt(alpha * 255), existingColor)

        pbxLightForeground.BackColor = adjustedColor

    End Sub

    Private Sub pbxDarkForeground_Click(sender As Object, e As EventArgs) Handles pbxDarkForeground.Click

        OpenColorPicker(6)

    End Sub

    Private Sub nudDarkForegroundAlpha_ValueChanged(sender As Object, e As EventArgs) Handles nudDarkForegroundAlpha.ValueChanged

        Dim alpha As Double = CDbl(nudDarkForegroundAlpha.Value)

        alpha = Math.Min(Math.Max(alpha, 0), 1)

        Dim existingColor As Color = pbxDarkForeground.BackColor

        Dim adjustedColor As Color = Color.FromArgb(CInt(alpha * 255), existingColor)

        pbxDarkForeground.BackColor = adjustedColor

    End Sub

    Private Sub pbxLightBackground_Click(sender As Object, e As EventArgs) Handles pbxLightBackground.Click

        OpenColorPicker(7)

    End Sub

    Private Sub nudLightBackgroundAlpha_ValueChanged(sender As Object, e As EventArgs) Handles nudLightBackgroundAlpha.ValueChanged

        Dim alpha As Double = CDbl(nudLightBackgroundAlpha.Value)

        alpha = Math.Min(Math.Max(alpha, 0), 1)

        Dim existingColor As Color = pbxLightBackground.BackColor

        Dim adjustedColor As Color = Color.FromArgb(CInt(alpha * 255), existingColor)

        pbxLightBackground.BackColor = adjustedColor

    End Sub

    Private Sub pbxDarkBackground_Click(sender As Object, e As EventArgs) Handles pbxDarkBackground.Click

        OpenColorPicker(8)

    End Sub

    Private Sub nudDarkBackgroundAlpha_ValueChanged(sender As Object, e As EventArgs) Handles nudDarkBackgroundAlpha.ValueChanged

        Dim alpha As Double = CDbl(nudDarkBackgroundAlpha.Value)

        alpha = Math.Min(Math.Max(alpha, 0), 1)

        Dim existingColor As Color = pbxDarkBackground.BackColor

        Dim adjustedColor As Color = Color.FromArgb(CInt(alpha * 255), existingColor)

        pbxDarkBackground.BackColor = adjustedColor

    End Sub

    Private Sub pbxLightOverlay_Click(sender As Object, e As EventArgs) Handles pbxLightOverlay.Click

        OpenColorPicker(9)

    End Sub

    Private Sub nudLightOverlayAlpha_ValueChanged(sender As Object, e As EventArgs) Handles nudLightOverlayAlpha.ValueChanged

        Dim alpha As Double = CDbl(nudLightOverlayAlpha.Value)

        alpha = Math.Min(Math.Max(alpha, 0), 1)

        Dim existingColor As Color = pbxLightOverlay.BackColor

        Dim adjustedColor As Color = Color.FromArgb(CInt(alpha * 255), existingColor)

        pbxLightOverlay.BackColor = adjustedColor

    End Sub

    Private Sub pbxDarkOverlay_Click(sender As Object, e As EventArgs) Handles pbxDarkOverlay.Click

        OpenColorPicker(10)

    End Sub

    Private Sub nudDarkOverlayAlpha_ValueChanged(sender As Object, e As EventArgs) Handles nudDarkOverlayAlpha.ValueChanged

        Dim alpha As Double = CDbl(nudDarkOverlayAlpha.Value)

        alpha = Math.Min(Math.Max(alpha, 0), 1)

        Dim existingColor As Color = pbxDarkOverlay.BackColor

        Dim adjustedColor As Color = Color.FromArgb(CInt(alpha * 255), existingColor)

        pbxDarkOverlay.BackColor = adjustedColor

    End Sub

    Private Sub pbxLightSeparator_Click(sender As Object, e As EventArgs) Handles pbxLightSeparator.Click

        OpenColorPicker(11)

    End Sub

    Private Sub nudLightSeparatorAlpha_ValueChanged(sender As Object, e As EventArgs) Handles nudLightSeparatorAlpha.ValueChanged

        Dim alpha As Double = CDbl(nudLightSeparatorAlpha.Value)

        alpha = Math.Min(Math.Max(alpha, 0), 1)

        Dim existingColor As Color = pbxLightSeparator.BackColor

        Dim adjustedColor As Color = Color.FromArgb(CInt(alpha * 255), existingColor)

        pbxLightSeparator.BackColor = adjustedColor

    End Sub

    Private Sub pbxDarkSeparator_Click(sender As Object, e As EventArgs) Handles pbxDarkSeparator.Click

        OpenColorPicker(12)

    End Sub

    Private Sub nudDarkSeparatorAlpha_ValueChanged(sender As Object, e As EventArgs) Handles nudDarkSeparatorAlpha.ValueChanged

        Dim alpha As Double = CDbl(nudDarkSeparatorAlpha.Value)

        alpha = Math.Min(Math.Max(alpha, 0), 1)

        Dim existingColor As Color = pbxDarkSeparator.BackColor

        Dim adjustedColor As Color = Color.FromArgb(CInt(alpha * 255), existingColor)

        pbxDarkSeparator.BackColor = adjustedColor

    End Sub

    Private Sub pbxLightBodyText_Click(sender As Object, e As EventArgs) Handles pbxLightBodyText.Click

        OpenColorPicker(13)

    End Sub

    Private Sub nudLightBodyTextAlpha_ValueChanged(sender As Object, e As EventArgs) Handles nudLightBodyTextAlpha.ValueChanged

        Dim alpha As Double = CDbl(nudLightBodyTextAlpha.Value)

        alpha = Math.Min(Math.Max(alpha, 0), 1)

        Dim existingColor As Color = pbxLightBodyText.BackColor

        Dim adjustedColor As Color = Color.FromArgb(CInt(alpha * 255), existingColor)

        pbxLightBodyText.BackColor = adjustedColor

    End Sub

    Private Sub pbxDarkBodyText_Click(sender As Object, e As EventArgs) Handles pbxDarkBodyText.Click

        OpenColorPicker(14)

    End Sub

    Private Sub nudDarkBodyTextAlpha_ValueChanged(sender As Object, e As EventArgs) Handles nudDarkBodyTextAlpha.ValueChanged

        Dim alpha As Double = CDbl(nudDarkBodyTextAlpha.Value)

        alpha = Math.Min(Math.Max(alpha, 0), 1)

        Dim existingColor As Color = pbxDarkBodyText.BackColor

        Dim adjustedColor As Color = Color.FromArgb(CInt(alpha * 255), existingColor)

        pbxDarkBodyText.BackColor = adjustedColor

    End Sub

    Private Sub pbxLightSubtitleText_Click(sender As Object, e As EventArgs) Handles pbxLightSubtitleText.Click

        OpenColorPicker(15)

    End Sub

    Private Sub nudLightSubtitleTextAlpha_ValueChanged(sender As Object, e As EventArgs) Handles nudLightSubtitleTextAlpha.ValueChanged

        Dim alpha As Double = CDbl(nudLightSubtitleTextAlpha.Value)

        alpha = Math.Min(Math.Max(alpha, 0), 1)

        Dim existingColor As Color = pbxLightSubtitleText.BackColor

        Dim adjustedColor As Color = Color.FromArgb(CInt(alpha * 255), existingColor)

        pbxLightSubtitleText.BackColor = adjustedColor

    End Sub

    Private Sub pbxDarkSubtitleText_Click(sender As Object, e As EventArgs) Handles pbxDarkSubtitleText.Click

        OpenColorPicker(16)

    End Sub

    Private Sub nudDarkSubtitleTextAlpha_ValueChanged(sender As Object, e As EventArgs) Handles nudDarkSubtitleTextAlpha.ValueChanged

        Dim alpha As Double = CDbl(nudDarkSubtitleTextAlpha.Value)

        alpha = Math.Min(Math.Max(alpha, 0), 1)

        Dim existingColor As Color = pbxDarkSubtitleText.BackColor

        Dim adjustedColor As Color = Color.FromArgb(CInt(alpha * 255), existingColor)

        pbxDarkSubtitleText.BackColor = adjustedColor

    End Sub

    Private Sub pbxLightButtonBackground_Click(sender As Object, e As EventArgs) Handles pbxLightButtonBackground.Click

        OpenColorPicker(17)

    End Sub

    Private Sub nudLightButtonBackgroundAlpha_ValueChanged(sender As Object, e As EventArgs) Handles nudLightButtonBackgroundAlpha.ValueChanged

        Dim alpha As Double = CDbl(nudLightButtonBackgroundAlpha.Value)

        alpha = Math.Min(Math.Max(alpha, 0), 1)

        Dim existingColor As Color = pbxLightButtonBackground.BackColor

        Dim adjustedColor As Color = Color.FromArgb(CInt(alpha * 255), existingColor)

        pbxLightButtonBackground.BackColor = adjustedColor

    End Sub

    Private Sub pbxDarkButtonBackground_Click(sender As Object, e As EventArgs) Handles pbxDarkButtonBackground.Click

        OpenColorPicker(18)

    End Sub

    Private Sub nudDarkButtonBackgroundAlpha_ValueChanged(sender As Object, e As EventArgs) Handles nudDarkButtonBackgroundAlpha.ValueChanged

        Dim alpha As Double = CDbl(nudDarkButtonBackgroundAlpha.Value)

        alpha = Math.Min(Math.Max(alpha, 0), 1)

        Dim existingColor As Color = pbxDarkButtonBackground.BackColor

        Dim adjustedColor As Color = Color.FromArgb(CInt(alpha * 255), existingColor)

        pbxDarkButtonBackground.BackColor = adjustedColor

    End Sub

    Private Sub pbxLightButtonText_Click(sender As Object, e As EventArgs) Handles pbxLightButtonText.Click

        OpenColorPicker(19)

    End Sub

    Private Sub nudLightButtonTextAlpha_ValueChanged(sender As Object, e As EventArgs) Handles nudLightButtonTextAlpha.ValueChanged

        Dim alpha As Double = CDbl(nudLightButtonTextAlpha.Value)

        alpha = Math.Min(Math.Max(alpha, 0), 1)

        Dim existingColor As Color = pbxLightButtonText.BackColor

        Dim adjustedColor As Color = Color.FromArgb(CInt(alpha * 255), existingColor)

        pbxLightButtonText.BackColor = adjustedColor

    End Sub

    Private Sub pbxDarkButtonText_Click(sender As Object, e As EventArgs) Handles pbxDarkButtonText.Click

        OpenColorPicker(20)

    End Sub

    Private Sub nudDarkButtonTextAlpha_ValueChanged(sender As Object, e As EventArgs) Handles nudDarkButtonTextAlpha.ValueChanged

        Dim alpha As Double = CDbl(nudDarkButtonTextAlpha.Value)

        alpha = Math.Min(Math.Max(alpha, 0), 1)

        Dim existingColor As Color = pbxDarkButtonText.BackColor

        Dim adjustedColor As Color = Color.FromArgb(CInt(alpha * 255), existingColor)

        pbxDarkButtonText.BackColor = adjustedColor

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Set the initial alpha values for the PictureBox controls

        ' Light Accent
        pbxlightAccent.BackColor = colorButton1

        ' Dark Accent
        pbxDarkAccent.BackColor = colorButton2

        ' Light Accent Text
        pbxLightAccentText.BackColor = colorButton3

        ' Dark Accent Text
        pbxDarkAccentText.BackColor = colorButton4

        ' Light Foreground
        pbxLightForeground.BackColor = colorButton5

        ' Dark Foreground
        pbxDarkForeground.BackColor = colorButton6

        ' Light Background
        pbxLightBackground.BackColor = colorButton7

        ' Dark Background
        pbxDarkBackground.BackColor = colorButton8

        ' Light Overlay
        pbxLightOverlay.BackColor = colorButton9
        UpdatePictureBoxAlpha(pbxLightOverlay, colorButton9, nudLightOverlayAlpha)

        ' Dark Overlay
        pbxDarkOverlay.BackColor = colorButton10
        UpdatePictureBoxAlpha(pbxDarkOverlay, colorButton10, nudDarkOverlayAlpha)

        ' Light Separator
        pbxLightSeparator.BackColor = colorButton11
        UpdatePictureBoxAlpha(pbxLightSeparator, colorButton11, nudLightSeparatorAlpha)

        ' Dark Separator
        pbxDarkSeparator.BackColor = colorButton12
        UpdatePictureBoxAlpha(pbxDarkSeparator, colorButton12, nudDarkSeparatorAlpha)

        ' Light Body Text
        pbxLightBodyText.BackColor = colorButton13

        ' Dark Body Text
        pbxDarkBodyText.BackColor = colorButton14

        ' Light Subtitle Text
        pbxLightSubtitleText.BackColor = colorButton15

        ' Dark Subtitle Text
        pbxDarkSubtitleText.BackColor = colorButton16

        ' Light Button Background
        pbxLightButtonBackground.BackColor = colorButton17
        UpdatePictureBoxAlpha(pbxLightButtonBackground, colorButton17, nudLightButtonBackgroundAlpha)

        ' Dark Button Background
        pbxDarkButtonBackground.BackColor = colorButton18
        UpdatePictureBoxAlpha(pbxDarkButtonBackground, colorButton18, nudDarkButtonBackgroundAlpha)

        ' Light Button Text
        pbxLightButtonText.BackColor = colorButton19

        ' Dark Button Text
        pbxDarkButtonText.BackColor = colorButton20

    End Sub

    Private Sub UpdatePictureBoxAlpha(pictureBox As PictureBox, color As Color, numericUpDown As NumericUpDown)

        ' Get the current color of the PictureBox
        Dim currentColor As Color = pictureBox.BackColor

        ' Get the alpha value from the numerical up-down control
        Dim alpha As Double = numericUpDown.Value

        ' Ensure the alpha value is within the valid range
        alpha = Math.Min(Math.Max(alpha, 0), 1)

        ' Set the back color of the PictureBox with adjusted alpha and existing RGB values
        pictureBox.BackColor = Color.FromArgb(CInt(alpha * 255), currentColor.R, currentColor.G, currentColor.B)

    End Sub

End Class
