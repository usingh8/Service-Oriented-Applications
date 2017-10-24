<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:template match="/">
       <html>  <body>
			<h1>Persons</h1>
			<table border="1">
				<tr bgcolor="light blue"> 
					<td><b>Name</b></td> 
					<td><b>Credential</b></td> 
					<td><b>Phone(Work)</b></td> 
					<td><b>Phone(Cell)</b></td> 
					<td><b>Provider</b></td>
					<td><b>Category</b></td>
				
				</tr>
				<xsl:for-each select="Persons/Person">
					<xsl:sort select="Category" />
					<tr style="font-size: 10pt; font-family: verdana">
						<td><xsl:value-of select="Name/First"/></td>
						<td><xsl:value-of select="Credential/Id"/></td>
						<td><xsl:value-of select="Phone/Work"/></td>
						<td><xsl:value-of select="Phone/Cell"/></td>
						<td><xsl:value-of select="Phone/Cell/@provider"/></td>
						<td><xsl:value-of select="Category"/></td>
					</tr>
				</xsl:for-each>
			</table>
		</body> 
		</html>
    </xsl:template>
</xsl:stylesheet>
