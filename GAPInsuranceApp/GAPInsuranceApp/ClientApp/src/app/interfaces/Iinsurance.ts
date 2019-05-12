export interface IInsurance {
    id: number;
    clientId: number;
    name: string;
    description: string;
    coverages: string;
    coverageAmt: number;
    begining: Date;
    timePeriod: number;
    price: number;
    risk: Risks;
}

enum Risks {
    Alto = 1,
    MedioAlto,
    Medio,
    Bajo
}
