import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Constants } from '../constants';

@Injectable({
  providedIn: 'root',
})
export class ToastService {
  constructor(private messageService: MessageService) {}

  showSuccess(title: string, message: string) {
    this.messageService.add({
      severity: 'success',
      summary: title,
      detail: message,
    });
  }

  showInfo(title: string, message: string) {
    this.messageService.add({
      severity: 'info',
      summary: title,
      detail: message,
    });
  }

  showWarning(title: string, message: string) {
    this.messageService.add({
      severity: 'warn',
      summary: title,
      detail: message,
    });
  }

  showError(title: string, message: string) {
    this.messageService.add({
      severity: 'error',
      summary: title,
      detail: message,
    });
  }

  showGeneralError() {
    this.messageService.add({
      severity: 'error',
      summary: Constants.ERROR_SERVER,
      detail: Constants.ERROR_SERVER_MESSAGE,
    });
  }
}
