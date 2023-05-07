import ProbabilityInput from './components/probability-input'
import {getCombinedWith, getEither} from './services/probability-api'
import { useState } from "react";

const ProbabilityView = () => {

    const [pA, setPa] = useState(0.5);
    const [pB, setPb] = useState(0.5);

    const [result, setResult] = useState<number | null>(null);

    const either = async () => {
        const result = await getEither(pA, pB);
        setResult(result);
    }

    const combinedWith = async () => {
        const result = await getCombinedWith(pA, pB);
        setResult(result);
    }

    const isValid = () => pA >= 0 && pA <= 1 && pB >= 0 && pB <= 1;

    return (
        <>
            <h1>Probability Calculator</h1>
            <ProbabilityInput name={"A"} onChange={setPa} value={pA}  />
            <ProbabilityInput name={"B"} onChange={setPb} value={pB}  />

            {!isValid() && <span>Input values must be between 0 and 1</span>}

            <button disabled={!isValid()} onClick={either}>Either</button>
            <button disabled={!isValid()} onClick={combinedWith}>CombinedWith</button>

            <h2>Result</h2>
            {result !== null && <p data-testid="result">{result}</p>}
        </>
    )

}

export default ProbabilityView;