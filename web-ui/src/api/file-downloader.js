import { download } from '@/utils/downloader'
export function downloadAttachment(attachmentId) {
  return download('/api/file/attachment/' + attachmentId, '')
}

export function downloadFile(fileId) {
  return download('/api/file/' + fileId, '')
}
