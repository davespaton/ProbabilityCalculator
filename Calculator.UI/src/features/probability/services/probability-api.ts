import {get} from '../../../api'

const probabilitySlug = 'probability';

export const getEither = async (pa: number, pb: number) => get<number>(`${probabilitySlug}/either`, {pa, pb});
export const getCombinedWith = async (pa: number, pb: number) => get<number>(`${probabilitySlug}/combined-with`, {pa, pb});