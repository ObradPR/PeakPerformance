import { OutputEmitterRef } from "@angular/core";
import { FormGroup } from "@angular/forms";

export interface IModalMethods {
    closeModalEvent: OutputEmitterRef<boolean>;
    closeModal(): void;
    form: FormGroup;
    formInit(): void;
}