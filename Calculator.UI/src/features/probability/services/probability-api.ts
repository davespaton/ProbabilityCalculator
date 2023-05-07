import {get} from '../../../api'

const probabilitySlug = 'probability';

type CalculateProbabilityResponse = {
    probability: number;
 }

export const getEither = async (pa: number, pb: number) => get<CalculateProbabilityResponse>(`${probabilitySlug}/either`, {pa, pb});
export const getCombinedWith = async (pa: number, pb: number) => get<CalculateProbabilityResponse>(`${probabilitySlug}/combined-with`, {pa, pb});