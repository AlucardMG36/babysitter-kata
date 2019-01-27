import { ConfigurationService } from './shared/services/configuration/configuration.service';
import { Injectable } from '@angular/core';

@Injectable()
export class Bootstrapper {

    constructor(private _config: ConfigurationService) { }

    run() {
        return new Promise((resolve, reject) => {
            console.log('Bootstrapping the application');

            this._config.Load().then(() => {
                resolve(true);
            });
        });
    }
}
