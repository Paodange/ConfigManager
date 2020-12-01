import FileSaver from 'file-saver'
import XLSX from 'xlsx'

export function exportTableToFile(fileName, element, bookType) {
  /* generate workbook object from table */
  var wb = XLSX.utils.table_to_book(element)
  /* get binary string as output */
  var wbout = XLSX.write(wb, {
    bookType: bookType,
    bookSST: true,
    type: 'array'
  })
  try {
    FileSaver.saveAs(
      new Blob([wbout], { type: 'application/octet-stream' }),
      fileName
    )
  } catch (e) {
    if (typeof console !== 'undefined') console.log(e, wbout)
  }
  return wbout
}
