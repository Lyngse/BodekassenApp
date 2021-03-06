import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs/Rx';

@Injectable()
export class UtilService {
    public alert: BehaviorSubject<{ type: string, titel: string, message: string }> = new BehaviorSubject({ type: null, titel: null, message: null });
    public loading: BehaviorSubject<boolean> = new BehaviorSubject(false);
    public dataArray: any= {};

    displayLoading(value: boolean){
        setTimeout(() =>{
            this.loading.next(value);
        })
    }
}