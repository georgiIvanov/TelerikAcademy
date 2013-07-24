<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/">
    <html>
      <body>
        <h1>Albums</h1>
        <table bgcolor="#E0E0E0" cellspacing="1" cellpadding="5" style="text-align:center">
          <tr bgcolor="#EEEEEE">
            <td>
              <b>Album Name</b>
            </td>
            <td>
              <b>Artist</b>
            </td>
            <td>
              <b>Year</b>
            </td>
            <td>
              <b>Producer</b>
            </td>
            <td>
              <b>Price</b>
            </td>
            <td colspan="11">
              <b>Songs</b>
            </td>
          </tr>
          <xsl:for-each select="/catalogue/album">
            <tr bgcolor="white">
              <td>
                <xsl:value-of select="name"/>
              </td>
              <td>
                <xsl:value-of select="artist"/>
              </td>
              <td>
                <xsl:value-of select="year"/>
              </td>
              <td>
                <xsl:value-of select="producer"/>
              </td>
              <td>
                <xsl:value-of select="price"/>USD
              </td>
              <xsl:for-each select="trackListing/song">
                <td>
                  <xsl:value-of select="name"/>
                </td>
              </xsl:for-each>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
