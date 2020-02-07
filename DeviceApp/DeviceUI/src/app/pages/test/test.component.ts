import {Component, Pipe, PipeTransform } from '@angular/core';
import {TranslateService} from '@ngx-translate/core';

const TRANSLATIONS_EN = require('../../../assets/i18n/en-US.json');
const TRANSLATIONS_FR = require('../../../assets/i18n/fr-FR.json');
@Component({
  selector: 'app-test',
  templateUrl: 'test.component.html',   
})
@Pipe({name: 'usersPipe',
  pure: false
})
export class TestComponent {  
  constructor(public translate: TranslateService) {
    translate.addLangs(['en-US', 'fr-FR']);
    translate.setDefaultLang('en-US');
    
    const browserLang = translate.getBrowserLang();
    translate.use(browserLang.match(/en-US|fr-FR/) ? browserLang : 'en-US');
        
    console.log('Navigator Lang =', navigator.language);
    console.log('Current Lang =', translate.currentLang);
  }  
}