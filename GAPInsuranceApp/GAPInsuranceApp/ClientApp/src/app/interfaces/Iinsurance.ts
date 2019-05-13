import { Risks } from "../shared/risks";

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

