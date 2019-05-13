import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: 'convertRisks'
})
export class ConvertRisksPipe implements PipeTransform {
    transform(value: number){
        let risk: string = '';
        switch (value) {
            case 1:
                risk = 'Alto';
                break;
            case 2:
                risk = 'Medio-Alto';
                break;
            case 3:
                risk = 'Medio';
                break;
            case 4:
                risk = 'Bajo';
                break;
        }
        return risk;
    }
    
}